using UnityEngine;

public class MovePlataforma : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float velocidade = 4;
    public float distancia = 6;

    bool reverso = false;
    bool lateral = false;

    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (reverso == false)
        {
            transform.position += new Vector3(Time.deltaTime * velocidade, 0, 0);
            if (transform.position.x > distancia)
            {
                reverso = true;
            }
        }
        else
        {
            transform.position -= new Vector3(Time.deltaTime * velocidade, 0, 0);
            if (transform.position.x < -distancia)
            {
                reverso = false;
            }
        }
    }
}
