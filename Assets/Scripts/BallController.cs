using UnityEngine;

public class BallController : MonoBehaviour
{
    public float impulseForce = 10f;

    void Start()
    {
       
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.AddForce(Vector3.left * impulseForce, ForceMode.Impulse);
        }
    }
}