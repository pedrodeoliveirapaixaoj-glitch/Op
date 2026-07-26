using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSystem : MonoBehaviour
{
    public enum MenuState
    {
        MainMenu,
        CareerMode,
        MatchMode,
        Settings,
        TeamSelection
    }


    public MenuState currentMenu;


    void Start()
    {
        OpenMainMenu();
    }


    public void OpenMainMenu()
    {
        currentMenu = MenuState.MainMenu;

        Debug.Log("Menu Inicial aberto");
    }


    public void OpenCareer()
    {
        currentMenu = MenuState.CareerMode;

        Debug.Log("Modo Carreira iniciado");
    }


    public void PlayMatch()
    {
        currentMenu = MenuState.MatchMode;

        Debug.Log("Iniciando partida...");

        SceneManager.LoadScene("Stadium");
    }


    public void OpenSettings()
    {
        currentMenu = MenuState.Settings;

        Debug.Log("Configurações abertas");
    }


    public void OpenTeamSelection()
    {
        currentMenu = MenuState.TeamSelection;

        Debug.Log("Seleção de times aberta");
    }


    public void SelectTeam(string teamName)
    {
        Debug.Log(
            "Time escolhido: " + teamName
        );
    }


    public void ExitGame()
    {
        Debug.Log("Saindo do jogo...");

        Application.Quit();
    }
}
