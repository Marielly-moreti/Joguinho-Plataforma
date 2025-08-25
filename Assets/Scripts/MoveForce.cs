using UnityEngine;

public class MoveForce : MonoBehaviour
{
    public float velocidade = 5;
    public float velocidadeMaxima = 5;
    public float forcaPulo = 5;
    bool podePular = true;
    Rigidbody2D rigidbody;

    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        bool pulo = Input.GetAxisRaw("Jump") > 0; // Verifica se o bot�o de pulo foi pressionado
        float movimento = Input.GetAxisRaw("Horizontal");

        rigidbody.AddForce(new Vector2(movimento * velocidade, 0));

        rigidbody.linearVelocityX = Mathf.Clamp(rigidbody.linearVelocityX, -velocidadeMaxima, velocidadeMaxima);

        if (pulo == true && podePular == true)
        {
            rigidbody.AddForce(new Vector2(0, forcaPulo));
            podePular = false; // Impede pular novamente at� que o personagem toque o ch�o
            Invoke("ResetarPulo", 1); // Chama ResetarPulo ap�s um pequeno atraso
        }
    }

    void ResetarPulo()
    {
        podePular = true; // Permite pular novamente quando o personagem toca o ch�o
    }
}
