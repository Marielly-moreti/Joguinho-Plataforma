using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);

    void Start()
    {
        if (target == null)
        {
            Debug.Log("Você esqueceu de colocar um target neste script...");
            Destroy(this);
        }
    }

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
