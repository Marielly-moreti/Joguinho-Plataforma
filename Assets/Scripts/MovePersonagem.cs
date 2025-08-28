using UnityEngine;
using TMPro;

public class MovePersonagem : MonoBehaviour
{

    public float velocidade = 60;
    public float velocidadeMaxima = 1;
    public float forcaPulo = 9;

    bool podePular = true;
    
    int moedas = 0;

    TextMeshProUGUI textoMoedas;
    Vector3 inicio;
    Rigidbody2D rigidbody;
    Animator animator;
    bool viradoDireita = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
        animator = transform.GetComponent<Animator>();
        textoMoedas = GameObject.Find("Text (TMP)").transform.GetComponent<TextMeshProUGUI>();
        inicio = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float movimento = Input.GetAxisRaw("Horizontal");
        bool pulo = Input.GetAxisRaw("Jump") > 0; // Comparação na variável

        if (movimento == 1)
        {
            transform.eulerAngles = new Vector2(0, 0);
            viradoDireita = true;
        }
        if (movimento == -1)
        {
            transform.eulerAngles = new Vector2(0, 180);
            viradoDireita = false;
        }

        rigidbody.AddForce(new Vector2(movimento * velocidade, 0));
        rigidbody.linearVelocityX = Mathf.Clamp(rigidbody.linearVelocityX, -velocidadeMaxima, velocidadeMaxima);

        if (rigidbody.linearVelocityX < 0.1f && rigidbody.linearVelocityX > -0.1f)
        {
            animator.SetBool("estaAndando", false);
        }
        else
        {
            animator.SetBool("estaAndando", true);
        }

        if (pulo == true && podePular == true)
        {
            animator.SetBool("estaNoAr", true);
            rigidbody.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            podePular = false;
            //Invoke("ResetarPulo", 1); // Aguarda x segundos para chamar a função
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Coin") == true)
        {
            Destroy(collision.gameObject);
            moedas++;
            textoMoedas.text = "Coins:  <color=yellow>" + moedas + "</color>";
        }

        if (collision.CompareTag("Limbo"))
        {
            transform.position = inicio;
            Debug.Log("Você caiu! E perdeu suas moedas");
            moedas = 0;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constraints.camadaChao)
        {
            podePular = true;
            animator.SetBool("estaNoAr", false);
        }
    }
}
