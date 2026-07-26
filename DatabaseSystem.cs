using System.Collections.Generic;
using UnityEngine;

public class DatabaseSystem : MonoBehaviour
{
    [System.Serializable]
    public class PlayerData
    {
        public string playerName;
        public int age;
        public string position;

        public int overall;
        public int goals;
        public int assists;
        public int matches;
    }


    [System.Serializable]
    public class ClubData
    {
        public string clubName;
        public string country;

        public int trophies;
        public int reputation;
    }


    public List<PlayerData> players = new List<PlayerData>();
    public List<ClubData> clubs = new List<ClubData>();


    void Start()
    {
        LoadDatabase();
    }


    void LoadDatabase()
    {
        players.Add(new PlayerData
        {
            playerName = "Jogador Exemplo",
            age = 20,
            position = "Atacante",
            overall = 85,
            goals = 30,
            assists = 10,
            matches = 40
        });


        clubs.Add(new ClubData
        {
            clubName = "Football Stars FC",
            country = "Brasil",
            trophies = 5,
            reputation = 80
        });


        Debug.Log("Banco de dados carregado!");
    }


    public PlayerData GetPlayer(string name)
    {
        return players.Find(
            p => p.playerName == name
        );
    }


    public ClubData GetClub(string name)
    {
        return clubs.Find(
            c => c.clubName == name
        );
    }


    public void AddPlayer(PlayerData player)
    {
        players.Add(player);

        Debug.Log(
            "Novo jogador adicionado: " +
            player.playerName
        );
    }


    public void AddClub(ClubData club)
    {
        clubs.Add(club);

        Debug.Log(
            "Novo clube adicionado: " +
            club.clubName
        );
    }


    public void ShowDatabase()
    {
        Debug.Log(
            "Jogadores: " +
            players.Count +
            " | Clubes: " +
            clubs.Count
        );
    }
}
