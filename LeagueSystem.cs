using System.Collections.Generic;
using UnityEngine;

public class LeagueSystem : MonoBehaviour
{
    [System.Serializable]
    public class Team
    {
        public string teamName;
        public int points;
        public int wins;
        public int draws;
        public int losses;
        public int division;
    }


    public List<Team> teams = new List<Team>();

    public string leagueName = "Football League";


    void Start()
    {
        CreateLeague();
        UpdateTable();
    }


    void CreateLeague()
    {
        teams.Add(new Team
        {
            teamName = "Time Azul",
            division = 1
        });

        teams.Add(new Team
        {
            teamName = "Time Vermelho",
            division = 1
        });

        teams.Add(new Team
        {
            teamName = "Time Verde",
            division = 2
        });
    }


    public void AddWin(int teamIndex)
    {
        teams[teamIndex].wins++;
        teams[teamIndex].points += 3;

        UpdateTable();
    }


    public void AddDraw(int teamIndex)
    {
        teams[teamIndex].draws++;
        teams[teamIndex].points += 1;

        UpdateTable();
    }


    public void AddLoss(int teamIndex)
    {
        teams[teamIndex].losses++;

        UpdateTable();
    }


    void UpdateTable()
    {
        teams.Sort((a, b) => b.points.CompareTo(a.points));
    }


    public void CheckPromotion()
    {
        foreach (Team team in teams)
        {
            if (team.points >= 50 && team.division > 1)
            {
                team.division--;

                Debug.Log(
                    team.teamName +
                    " subiu de divisão!"
                );
            }
        }
    }


    public void CheckRelegation()
    {
        foreach (Team team in teams)
        {
            if (team.points < 15 && team.division < 3)
            {
                team.division++;

                Debug.Log(
                    team.teamName +
                    " foi rebaixado."
                );
            }
        }
    }


    public void ShowTable()
    {
        foreach (Team team in teams)
        {
            Debug.Log(
                team.teamName +
                " | Pontos: " +
                team.points +
                " | Divisão: " +
                team.division
            );
        }
    }
}
