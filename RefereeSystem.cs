using UnityEngine;

public class RefereeSystem : MonoBehaviour
{
    public GameManager gameManager;

    public bool matchStarted = false;
    public bool matchFinished = false;

    void Start()
    {
        if (gameManager == null)
        {
            gameManager = GameManager.Instance;
        }

        StartMatch();
    }

    public void StartMatch()
    {
        matchStarted = true;
        matchFinished = false;

        Debug.Log("O árbitro apitou! Começou a partida.");

        if (gameManager != null)
        {
            gameManager.StartMatch();
        }
    }

    public void EndMatch()
    {
        if (matchFinished)
            return;

        matchFinished = true;

        Debug.Log("Fim de jogo!");

        if (gameManager != null)
        {
            gameManager.EndMatch();
        }
    }

    public void RegisterFoul(GameObject player)
    {
        Debug.Log("Falta cometida por: " + player.name);
    }

    public void GiveYellowCard(GameObject player)
    {
        Debug.Log("Cartão amarelo para: " + player.name);
    }

    public void GiveRedCard(GameObject player)
    {
        Debug.Log("Cartão vermelho para: " + player.name);
    }

    public void RestartKickOff()
    {
        Debug.Log("Reiniciando a partida no meio-campo.");
    }
}
