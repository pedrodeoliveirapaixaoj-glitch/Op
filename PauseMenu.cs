using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;

    private bool paused = false;

    public void TogglePause()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0f;
            pausePanel.SetActive(true);
        }
        else
        {
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }

    public void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
    }

    public void PauseGame()
    {
        paused = true;
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
    }

    public void QuitToMenu()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
    }
}
