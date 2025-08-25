using UnityEngine;

public class MovePersonagem : MonoBehaviour
{

    public float velocidade = 5f;
    public float velocidadeMaxima = 5f;
    public float forcaPulo = 5f;
    bool podePular = true;
    Rigidbody2D rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float movimento = Input.GetAxisRaw("Horizontal");
        bool pulo = Input.GetAxisRaw("Jump") > 0; // Comparação na variável

        rigidbody.AddForce(new Vector2(movimento * velocidade, 0));
        rigidbody.linearVelocityX = Mathf.Clamp(rigidbody.linearVelocityX, -velocidadeMaxima, velocidadeMaxima);

        if (pulo == true && podePular == true)
        {
            rigidbody.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            podePular = false;
            //Invoke("ResetarPulo", 1); // Aguarda x segundos para chamar a função
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Moeda") == true)
        {
            Destroy(collision.gameObject, 1);
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == Constraints.camadaChao)
        {
            podePular = true;
        }
    }
}
