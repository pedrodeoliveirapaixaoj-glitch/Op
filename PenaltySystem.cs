using UnityEngine;

public class PenaltySystem : MonoBehaviour
{
    public int playerGoals = 0;
    public int goalkeeperSaves = 0;

    public int totalPenalties = 5;
    private int currentPenalty = 0;

    public bool playerTurn = true;

    public void StartPenaltyShootout()
    {
        playerGoals = 0;
        goalkeeperSaves = 0;
        currentPenalty = 0;

        Debug.Log("Começou a disputa de pênaltis!");
    }

    public void ShootPenalty(float accuracy)
    {
        if (currentPenalty >= totalPenalties)
        {
            FinishPenalty();
            return;
        }

        currentPenalty++;

        float goalkeeperChance = Random.Range(0f, 100f);

        if (accuracy > goalkeeperChance)
        {
            playerGoals++;
            Debug.Log("GOOOOOL! Pênalti convertido!");
        }
        else
        {
            goalkeeperSaves++;
            Debug.Log("DEFENDEU O GOLEIRO!");
        }

        CheckPenaltyEnd();
    }

    public void GoalkeeperDive()
    {
        Debug.Log("Goleiro pulou para defender!");
    }

    void CheckPenaltyEnd()
    {
        if (currentPenalty >= totalPenalties)
        {
            FinishPenalty();
        }
    }

    void FinishPenalty()
    {
        Debug.Log("Fim dos pênaltis!");

        if (playerGoals > goalkeeperSaves)
        {
            Debug.Log("Vitória nos pênaltis!");
        }
        else if (playerGoals < goalkeeperSaves)
        {
            Debug.Log("Derrota nos pênaltis!");
        }
        else
        {
            Debug.Log("Empate! Precisa de mais cobranças.");
        }
    }
}
