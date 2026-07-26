using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Placar")]
    public int homeScore = 0;
    public int awayScore = 0;

    [Header("Tempo")]
    public float matchTime = 300f; // 5 minutos
    private float currentTime;
    public bool matchRunning = false;

    public enum MatchState
    {
        Menu,
        KickOff,
        Playing,
        Paused,
        Finished
    }

    public MatchState State = MatchState.Menu;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentTime = matchTime;
    }

    private void Update()
    {
        if (!matchRunning)
            return;

        currentTime -= Time.deltaTime;

        if (currentTime <= 0)
        {
            currentTime = 0;
            EndMatch();
        }
    }

    public void StartMatch()
    {
        homeScore = 0;
        awayScore = 0;
        currentTime = matchTime;
        matchRunning = true;
        State = MatchState.Playing;
    }

    public void PauseMatch()
    {
        matchRunning = false;
        State = MatchState.Paused;
        Time.timeScale = 0f;
    }

    public void ResumeMatch()
    {
        matchRunning = true;
        State = MatchState.Playing;
        Time.timeScale = 1f;
    }

    public void GoalHome()
    {
        homeScore++;
        Debug.Log("Gol do Time da Casa!");
    }

    public void GoalAway()
    {
        awayScore++;
        Debug.Log("Gol do Time Visitante!");
    }

    public void EndMatch()
    {
        matchRunning = false;
        State = MatchState.Finished;

        Debug.Log("Fim da partida!");
        Debug.Log(homeScore + " x " + awayScore);
    }

    public string GetTimer()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);

        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(sceneName);
    }

    public void RestartMatch()
    {
        LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
