using System.Collections.Generic;
using UnityEngine;

public class RankingSystem : MonoBehaviour
{
    [System.Serializable]
    public class RankedPlayer
    {
        public string playerName;
        public int points;
        public int goals;
        public int assists;
        public int rank;
    }

    public List<RankedPlayer> players = new List<RankedPlayer>();


    void Start()
    {
        CreateRanking();
        UpdateRanking();
    }


    void CreateRanking()
    {
        players.Add(new RankedPlayer
        {
            playerName = "Craque A",
            goals = 50,
            assists = 20,
            points = 100
        });

        players.Add(new RankedPlayer
        {
            playerName = "Craque B",
            goals = 40,
            assists = 30,
            points = 90
        });
    }


    public void AddPerformance(string name, int goals, int assists)
    {
        RankedPlayer player = players.Find(p => p.playerName == name);

        if (player == null)
            return;

        player.goals += goals;
        player.assists += assists;

        player.points += (goals * 3) + (assists * 2);

        UpdateRanking();
    }


    void UpdateRanking()
    {
        players.Sort((a, b) => b.points.CompareTo(a.points));

        for (int i = 0; i < players.Count; i++)
        {
            players[i].rank = i + 1;
        }
    }


    public void ShowRanking()
    {
        foreach (RankedPlayer player in players)
        {
            Debug.Log(
                player.rank +
                "º - " +
                player.playerName +
                " | Pontos: " +
                player.points
            );
        }
    }
}
