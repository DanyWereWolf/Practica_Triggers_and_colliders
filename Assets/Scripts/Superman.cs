using UnityEngine;

public class Superman : MonoBehaviour
{
    public float impactForce = 10f; 

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody otherRigidbody = collision.gameObject.GetComponent<Rigidbody>();

        if (otherRigidbody != null)
        {
            if (collision.gameObject.layer == LayerMask.NameToLayer("BadGuy"))
            {
                // Наносим удар
                Vector3 direction = (collision.transform.position - transform.position).normalized;
                otherRigidbody.AddForce(direction * impactForce, ForceMode.Impulse);
            }
        }
    }
}