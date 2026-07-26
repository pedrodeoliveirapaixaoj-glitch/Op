using UnityEngine;

public class GoalSystem : MonoBehaviour
{
    public enum GoalSide
    {
        Home,
        Away
    }

    public GoalSide goalSide;

    public Transform ballSpawnPoint;
    public Rigidbody ballRigidbody;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Ball"))
            return;

        if (goalSide == GoalSide.Home)
        {
            GameManager.Instance.GoalAway();
        }
        else
        {
            GameManager.Instance.GoalHome();
        }

        ResetBall(other.gameObject);
    }

    void ResetBall(GameObject ball)
    {
        Rigidbody rb = ball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
        }

        if (ballSpawnPoint != null)
        {
            ball.transform.position = ballSpawnPoint.position;
        }

        Debug.Log("Gol! Reiniciando a partida...");
    }
}
