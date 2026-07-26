using UnityEngine;

public class CareerMode : MonoBehaviour
{
    public string coachName = "Novo Treinador";
    public string teamName = "Meu Time";

    public int season = 1;
    public int wins = 0;
    public int draws = 0;
    public int losses = 0;

    public int money = 500000; // orçamento do clube

    public int reputation = 50; // 0 a 100

    public void StartCareer(string newCoach, string newTeam)
    {
        coachName = newCoach;
        teamName = newTeam;

        season = 1;
        wins = 0;
        draws = 0;
        losses = 0;

        Debug.Log("Carreira iniciada!");
        Debug.Log("Treinador: " + coachName);
        Debug.Log("Time: " + teamName);
    }

    public void WinMatch()
    {
        wins++;
        money += 10000;
        reputation += 2;

        Debug.Log("Vitória! Recompensa recebida.");
    }

    public void DrawMatch()
    {
        draws++;
        money += 5000;

        Debug.Log("Empate na partida.");
    }

    public void LoseMatch()
    {
        losses++;
        reputation -= 1;

        Debug.Log("Derrota.");
    }

    public void NextSeason()
    {
        season++;

        wins = 0;
        draws = 0;
        losses = 0;

        Debug.Log("Nova temporada: " + season);
    }

    public string GetCareerStats()
    {
        return
        "Treinador: " + coachName +
        "\nTime: " + teamName +
        "\nTemporada: " + season +
        "\nVitórias: " + wins +
        "\nEmpates: " + draws +
        "\nDerrotas: " + losses +
        "\nReputação: " + reputation;
    }
}
