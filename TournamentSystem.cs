using System.Collections.Generic;
using UnityEngine;

public class TournamentSystem : MonoBehaviour
{
    [System.Serializable]
    public class Team
    {
        public string teamName;
        public int points;
        public int wins;
        public int draws;
        public int losses;
    }

    public string tournamentName = "Football 2026 Cup";

    public List<Team> teams = new List<Team>();

    public int currentRound = 1;

    void Start()
    {
        CreateTournament();
    }

    void CreateTournament()
    {
        teams.Add(new Team
        {
            teamName = "Time Azul"
        });

        teams.Add(new Team
        {
            teamName = "Time Vermelho"
        });

        teams.Add(new Team
        {
            teamName = "Time Verde"
        });

        teams.Add(new Team
        {
            teamName = "Time Dourado"
        });

        Debug.Log("Campeonato criado: " + tournamentName);
    }

    public void AddWin(int teamIndex)
    {
        teams[teamIndex].wins++;
        teams[teamIndex].points += 3;
    }

    public void AddDraw(int teamIndex)
    {
        teams[teamIndex].draws++;
        teams[teamIndex].points += 1;
    }

    public void AddLoss(int teamIndex)
    {
        teams[teamIndex].losses++;
    }

    public void NextRound()
    {
        currentRound++;

        Debug.Log("Próxima rodada: " + currentRound);
    }

    public void ShowRanking()
    {
        foreach (Team team in teams)
        {
            Debug.Log(
                team.teamName +
                " - Pontos: " + team.points
            );
        }
    }
}
