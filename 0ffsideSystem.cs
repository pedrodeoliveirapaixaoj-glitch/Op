using UnityEngine;

public class OffsideSystem : MonoBehaviour
{
    public Transform attackingPlayer;
    public Transform ball;
    public Transform[] defenders;

    public bool offsideDetected = false;

    public void CheckOffside()
    {
        if (attackingPlayer == null || ball == null || defenders.Length == 0)
            return;

        float lastDefenderPosition = GetLastDefenderPosition();

        if (attackingPlayer.position.x > lastDefenderPosition &&
            attackingPlayer.position.x > ball.position.x)
        {
            offsideDetected = true;

            Debug.Log("🚩 IMPEDIMENTO!");
        }
        else
        {
            offsideDetected = false;

            Debug.Log("Jogada legal.");
        }
    }

    float GetLastDefenderPosition()
    {
        float position = defenders[0].position.x;

        foreach (Transform defender in defenders)
        {
            if (defender.position.x > position)
            {
                position = defender.position.x;
            }
        }

        return position;
    }

    public void StopPlay()
    {
        if (offsideDetected)
        {
            Debug.Log("Árbitro parou a jogada por impedimento.");
        }
    }
}
