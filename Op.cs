using UnityEngine;

public class TouchInput : MonoBehaviour
{
    public PlayerController player;
    public BallController ball;

    public Transform shootTarget;

    public void OnPassButton()
    {
        if (ball != null)
        {
            ball.Pass(player.transform.forward);
        }
    }

    public void OnShootButton()
    {
        if (ball != null)
        {
            ball.Shoot(shootTarget.forward);
        }
    }

    public void OnSprintButtonDown()
    {
        player.StartSprint();
    }

    public void OnSprintButtonUp()
    {
        player.StopSprint();
    }

    public void OnSlideButton()
    {
        Debug.Log("Dividida!");
        // Aqui será adicionada a animação da dividida.
    }
}
