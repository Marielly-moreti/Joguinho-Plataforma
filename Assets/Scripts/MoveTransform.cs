using UnityEngine;

public class MoveTransform : MonoBehaviour
{
    public float velocidade = 5;

    void Update()
    {
        float movimento = Input.GetAxisRaw("Horizontal")* Time.deltaTime;
        float voando = Input.GetAxisRaw("Vertical") * Time.deltaTime;
        transform.position += new Vector3(movimento * velocidade, voando * velocidade);
    }
}
