using System.Collections.Generic;
using UnityEngine;

public class TeamManager : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int number;
        public string position;
        public int overall;

        public bool starter;
    }

    public List<PlayerData> players = new List<PlayerData>();

    void Start()
    {
        if (players.Count == 0)
        {
            CreateDefaultTeam();
        }
    }

    void CreateDefaultTeam()
    {
        players.Add(new PlayerData { playerName = "Goleiro", number = 1, position = "GK", overall = 75, starter = true });

        players.Add(new PlayerData { playerName = "Lateral Direito", number = 2, position = "RB", overall = 73, starter = true });

        players.Add(new PlayerData { playerName = "Zagueiro 1", number = 3, position = "CB", overall = 76, starter = true });

        players.Add(new PlayerData { playerName = "Zagueiro 2", number = 4, position = "CB", overall = 75, starter = true });

        players.Add(new PlayerData { playerName = "Lateral Esquerdo", number = 6, position = "LB", overall = 74, starter = true });

        players.Add(new PlayerData { playerName = "Meio 1", number = 8, position = "CM", overall = 78, starter = true });

        players.Add(new PlayerData { playerName = "Meio 2", number = 10, position = "CM", overall = 80, starter = true });

        players.Add(new PlayerData { playerName = "Volante", number = 5, position = "CDM", overall = 77, starter = true });

        players.Add(new PlayerData { playerName = "Ponta Direita", number = 7, position = "RW", overall = 81, starter = true });

        players.Add(new PlayerData { playerName = "Centroavante", number = 9, position = "ST", overall = 84, starter = true });

        players.Add(new PlayerData { playerName = "Ponta Esquerda", number = 11, position = "LW", overall = 82, starter = true });
    }

    public void AddPlayer(PlayerData player)
    {
        players.Add(player);
    }

    public void RemovePlayer(PlayerData player)
    {
        players.Remove(player);
    }

    public PlayerData GetPlayer(int index)
    {
        return players[index];
    }

    public int GetTeamOverall()
    {
        int total = 0;

        foreach (PlayerData player in players)
        {
            total += player.overall;
        }

        return total / players.Count;
    }
}
