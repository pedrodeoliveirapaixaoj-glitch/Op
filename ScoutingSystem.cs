using System.Collections.Generic;
using UnityEngine;

public class ScoutingSystem : MonoBehaviour
{
    [System.Serializable]
    public class ScoutPlayer
    {
        public string playerName;
        public int age;
        public string country;
        public int overall;
        public int potential;
    }

    public List<ScoutPlayer> discoveredPlayers = new List<ScoutPlayer>();

    public int scoutingPoints = 100;


    public void SearchTalent(string region)
    {
        if (scoutingPoints <= 0)
        {
            Debug.Log("Sem pontos de observação!");
            return;
        }

        scoutingPoints -= 10;

        ScoutPlayer newTalent = new ScoutPlayer();

        newTalent.playerName = "Talento " + Random.Range(1, 999);
        newTalent.age = Random.Range(16, 21);
        newTalent.country = region;
        newTalent.overall = Random.Range(55, 75);
        newTalent.potential = Random.Range(80, 95);

        discoveredPlayers.Add(newTalent);

        Debug.Log(
            "Novo talento encontrado: " +
            newTalent.playerName +
            " Potencial: " +
            newTalent.potential
        );
    }


    public ScoutPlayer GetBestTalent()
    {
        ScoutPlayer best = null;

        foreach (ScoutPlayer player in discoveredPlayers)
        {
            if (best == null || player.potential > best.potential)
            {
                best = player;
            }
        }

        return best;
    }


    public void ShowReports()
    {
        foreach (ScoutPlayer player in discoveredPlayers)
        {
            Debug.Log(
                player.playerName +
                " | Idade: " + player.age +
                " | País: " + player.country +
                " | Overall: " + player.overall +
                " | Potencial: " + player.potential
            );
        }
    }
}
