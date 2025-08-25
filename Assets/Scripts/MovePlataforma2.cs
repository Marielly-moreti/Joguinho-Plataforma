using Unity.VisualScripting;
using UnityEngine;

public class MovePlataforma2 : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float velocidade = 4;
    public float distancia = 6;

    bool reverso = false;

    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!reverso)
        {
            transform.position += new Vector3(0, Time.deltaTime * velocidade, 0);
            if (transform.position.y > distancia)
            {
                reverso = true;
            }
        }
        else
        {
            transform.position -= new Vector3(0, Time.deltaTime * velocidade, 0);
            if (transform.position.y < -distancia)
            {
                reverso = false;
            }
        }
    }
}

