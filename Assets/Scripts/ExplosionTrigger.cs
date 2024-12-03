using UnityEngine;

public class ExplosionTrigger : MonoBehaviour
{
    public GameObject explosionCenter;
    public float explosionRadius = 5f;
    public float explosionForce = 700f;

  
    public void TriggerExplosion()
    {
        Collider[] colliders = Physics.OverlapSphere(explosionCenter.transform.position, explosionRadius);

        foreach (Collider collider in colliders)
        {
            Rigidbody rb = collider.GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 explosionDirection = collider.transform.position - explosionCenter.transform.position;
                rb.AddForce(explosionDirection.normalized * explosionForce);
            }
        }
    }
}