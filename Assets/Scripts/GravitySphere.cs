using UnityEngine;

public class GravitySphereController : MonoBehaviour
{
    public Vector3[] points;
    public float speed = 2.0f;
    private int currentPointIndex = 0;
    private int direction = 1;
    bool forward = true;

    void Update()
    {
        Vector3 targetPosition = points[currentPointIndex];
        float step = speed * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
        transform.LookAt(targetPosition);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            if (forward == true)
            {
                currentPointIndex += direction;
            }

            if (currentPointIndex >= points.Length || currentPointIndex < 0)
            {
                direction *= -1;
                currentPointIndex = Mathf.Clamp(currentPointIndex, 0, points.Length - 1);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false; // Отключаем гравитацию
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = true; // Включаем гравитацию
        }
    }
}
