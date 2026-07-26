using UnityEngine;

public class GoalkeeperAI : MonoBehaviour
{
    public Transform ball;
    public float moveSpeed = 4f;
    public float maxDistance = 4f;

    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (ball == null)
            return;

        Vector3 target = startPosition;

        float offsetX = Mathf.Clamp(
            ball.position.x - startPosition.x,
            -maxDistance,
            maxDistance
        );

        target.x = startPosition.x + offsetX;

        transform.position = Vector3.MoveTowards(
            transform.position,
            target,
            moveSpeed * Time.deltaTime
        );

        transform.LookAt(ball);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ball"))
        {
            Rigidbody rb = collision.gameObject.GetComponent<Rigidbody>();

            if (rb != null)
            {
                Vector3 clearDirection =
                    (collision.transform.position - transform.position).normalized;

                rb.AddForce(clearDirection * 12f, ForceMode.Impulse);
            }
        }
    }
}
