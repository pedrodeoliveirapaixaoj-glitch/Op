using UnityEngine;

public class MatchManager : MonoBehaviour
{
    public GameManager gameManager;
    public RefereeSystem referee;

    public float firstHalfTime = 300f; // 5 minutos
    public float halfTimeDuration = 15f;

    private bool firstHalfFinished = false;
    private bool secondHalfStarted = false;

    void Start()
    {
        if (gameManager == null)
            gameManager = GameManager.Instance;

        referee.StartMatch();
    }

    void Update()
    {
        if (gameManager == null)
            return;

        if (!firstHalfFinished && gameManager.GetTimer() == "00:00")
        {
            FirstHalfEnd();
        }
    }

    void FirstHalfEnd()
    {
        firstHalfFinished = true;

        Debug.Log("Intervalo!");

        Invoke(nameof(StartSecondHalf), halfTimeDuration);
    }

    void StartSecondHalf()
    {
        secondHalfStarted = true;

        gameManager.StartMatch();

        Debug.Log("Começou o segundo tempo!");
    }

    public void EndMatch()
    {
        referee.EndMatch();

        Debug.Log("Resultado Final: " +
            gameManager.homeScore + " x " +
            gameManager.awayScore);
    }
}
