using UnityEngine;

public class MoveVelocity : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float velocidade = 5;

    void Start()
    {
        rigidbody = transform.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float movimento = Input.GetAxisRaw("Horizontal");
        rigidbody.linearVelocity += new Vector2(movimento * velocidade, 0);
    }
}
