using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerAI : MonoBehaviour
{
    public Transform ball;
    public Transform opponentGoal;

    public float moveSpeed = 5f;
    public float chaseDistance = 20f;
    public float kickDistance = 2f;
    public float shootForce = 20f;

    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (ball == null)
            return;

        float distance = Vector3.Distance(transform.position, ball.position);

        if (distance <= chaseDistance)
        {
            Vector3 direction = (ball.position - transform.position).normalized;

            controller.Move(direction * moveSpeed * Time.deltaTime);

            if (direction != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(
                    transform.rotation,
                    Quaternion.LookRotation(direction),
                    8f * Time.deltaTime
                );
            }

            if (distance <= kickDistance)
            {
                ShootBall();
            }
        }
    }

    void ShootBall()
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            Vector3 direction =
                (opponentGoal.position - ball.position).normalized;

            rb.linearVelocity = Vector3.zero;
            rb.AddForce(direction * shootForce, ForceMode.Impulse);
        }
    }
}
