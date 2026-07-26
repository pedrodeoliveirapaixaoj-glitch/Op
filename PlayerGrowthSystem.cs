using System.Collections.Generic;
using UnityEngine;

public class PlayerGrowthSystem : MonoBehaviour
{
    [System.Serializable]
    public class Player
    {
        public string playerName;

        public int age;
        public int overall;
        public int potential;

        public bool youthAcademy;
    }

    public List<Player> players = new List<Player>();


    public void CreateYouthPlayer(string name)
    {
        Player newPlayer = new Player();

        newPlayer.playerName = name;
        newPlayer.age = Random.Range(16, 19);
        newPlayer.overall = Random.Range(50, 65);
        newPlayer.potential = Random.Range(80, 95);
        newPlayer.youthAcademy = true;

        players.Add(newPlayer);

        Debug.Log("Novo jogador da base: " + name);
    }


    public void EndSeason()
    {
        foreach (Player player in players)
        {
            GrowPlayer(player);
        }

        Debug.Log("Temporada finalizada. Jogadores evoluíram!");
    }


    void GrowPlayer(Player player)
    {
        player.age++;

        if (player.age <= 23)
        {
            // Jovens evoluem mais rápido
            player.overall += Random.Range(1, 4);
        }
        else if (player.age <= 30)
        {
            // Auge da carreira
            player.overall += Random.Range(0, 2);
        }
        else
        {
            // Declínio
            player.overall -= Random.Range(1, 3);
        }


        if (player.overall > player.potential)
        {
            player.overall = player.potential;
        }

        if (player.overall < 1)
        {
            player.overall = 1;
        }
    }


    public Player GetBestYoungPlayer()
    {
        Player best = null;

        foreach (Player player in players)
        {
            if (player.youthAcademy)
            {
                if (best == null || player.potential > best.potential)
                {
                    best = player;
                }
            }
        }

        return best;
    }
}
