using UnityEditor.U2D.Aseprite;
using UnityEngine;
using TMPro;

public class Personagem : MonoBehaviour
{

    public float velocidade = 5;
    public float velocidadeMaxima = 5;
    public float forcaPulo = 10;
    public float distanciaRaycast = 0.6f;

    bool podePular = true;

    Rigidbody2D rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        // Lógica do movimento

        float horizontal = Input.GetAxisRaw("Horizontal");
        horizontal = horizontal * velocidade * Time.deltaTime;

        Vector2 movimento = new Vector2(horizontal, 0);

        rigidbody.linearVelocity += movimento;
        rigidbody.linearVelocityX = Mathf.Clamp(rigidbody.linearVelocityX, -velocidadeMaxima, velocidadeMaxima);

        // Lógica do pulo

        // Forma 3 de fazer o pulo: raycast
        podePular = Physics2D.Raycast(
            transform.position,
            Vector2.down,
            distanciaRaycast,
            LayerMask.GetMask("Ground")
        );

        // Forma 2 de fazer o pulo: verificando sobreposição de colisões
        //podePular = Physics2D.OverlapBox(
        //    groundChecker.position,
        //    groundChecker.GetComponent<BoxCollider2D>().bounds.size,
        //    0,
        //    LayerMask.GetMask("Chao")
        //);

        bool pulo = Input.GetButtonDown("Jump");
        if (pulo == true && podePular == true)
        {
            rigidbody.AddForce(new Vector2(0, forcaPulo), ForceMode2D.Impulse);
            podePular = false;
        }

    }

    // Forma 1 de fazer o pulo: com colisões
    //void OnCollisionEnter2D(Collision2D collision)
    //{
    //    //if (collision.gameObject.layer == LayerMask.GetMask("Chao"))
    //    if (collision.gameObject.layer == Constraints.camadaChao)
    //    {
    //        podePular = true;
    //    }
    //}



}




/*
 
    -----|-----|-----| ATIVIDADE |-----|-----|----- 
    
    Criar uma scene nova para fazer a atividade.

    Sua scene deve ter:
    
    1. Um personagem que se move e pula
        -- Você NÃO DEVE usar o linearVelocity para se mover
        -- Use o addForce ou movimentação pelo transform
    
    2. Moedas para serem pegas
        -- Ao pegar uma moeda, mostre o contador no console

    3. Adicione plataformas móveis horizontais e verticais
        -- ATENÇÃO: você PRECISA criar esse script usando
           o ChatGPT ou outra IA de sua preferência

    4. Se o personagem cair fora da fase, ele deve perder
        todas as moedas e voltar para o início

    5. Ao chegar no final da fase deve aparecer uma mensagem
        indicando que o jogador venceu




 
 
 */