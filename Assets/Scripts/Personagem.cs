using UnityEngine;

public class Personagem : MonoBehaviour
{
    public float forcaPulo = 10;
    public float velocidade = 5;
    public float velocidadeMaxima = 5;
    public Transform GroundCheck; // Transform para verificar se o personagem está no chão

    bool podePular = true;

    Rigidbody2D rb;


    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        horizontal = horizontal * velocidade * Time.deltaTime;

        podePular = Physics2D.OverlapBox(GroundCheck.position, GroundCheck.GetComponent<BoxCollider2D>().bounds.size, 0, Constraints.camadaChao);

        bool pulo = Input.GetAxisRaw("Jump") > 0; // Verifica se o botão de pulo foi pressionado
        if (pulo == true && podePular == true)
        {
            rb.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            podePular = false; // Impede pular novamente até que o personagem toque o chão
        }

        Vector2 movimento = new Vector2(horizontal, 0);

        rb.linearVelocity += movimento;
        rb.linearVelocityX = Mathf.Clamp(rb.linearVelocityX, -velocidadeMaxima, velocidadeMaxima);

    }

    //Forma 1 de fazer o pulo: com colisões
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (collision.gameObject.layer == Constraints.camadaChao)
    //    {
    //        podePular = true; // Permite pular novamente quando o personagem toca o chão
    //    }
    //}
}
