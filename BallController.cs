using UnityEngine;

public class BallController : MonoBehaviour
{
    public Rigidbody rb;

    public float passForce = 15f;
    public float shootForce = 30f;

    void Awake()
    {
        if (rb == null)
            rb = GetComponent<Rigidbody>();
    }

    public void Pass(Vector3 direction)
    {
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(direction.normalized * passForce, ForceMode.Impulse);
    }

    public void Shoot(Vector3 direction)
    {
        rb.linearVelocity = Vector3.zero;
        rb.AddForce(direction.normalized * shootForce, ForceMode.Impulse);
    }

    public void StopBall()
    {
        rb.linearVelocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
    }
}
