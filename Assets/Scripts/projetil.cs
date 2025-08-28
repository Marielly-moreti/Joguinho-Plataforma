using UnityEngine;

public class projetil : MonoBehaviour
{
   public Vector3 direcao;
    public float velocidade = 20;
    void Start()
    {
        
    }

    void Update()
    {
        transform.position += direcao * velocidade * Time.deltaTime;
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(transform.gameObject);
    }
}
