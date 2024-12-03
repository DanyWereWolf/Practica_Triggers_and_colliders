using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float range = 5f;

    private Vector3 targetPosition;

    void Start()
    {
        SetRandomTargetPosition();
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetRandomTargetPosition();
        }
    }

    void SetRandomTargetPosition()
    {
        float randomX = Random.Range(-range, range);
        float randomZ = Random.Range(-range, range);
        targetPosition = new Vector3(randomX, transform.position.y, randomZ);
    }
}
