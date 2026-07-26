using System.Collections.Generic;
using UnityEngine;

public class InjurySystem : MonoBehaviour
{
    [System.Serializable]
    public class PlayerInjury
    {
        public string playerName;
        public bool injured;
        public string injuryType;
        public int recoveryDays;
    }

    public List<PlayerInjury> players = new List<PlayerInjury>();


    public void CheckInjury(string playerName)
    {
        PlayerInjury player = players.Find(p => p.playerName == playerName);

        if (player == null)
        {
            Debug.Log("Jogador não encontrado.");
            return;
        }

        int chance = Random.Range(0, 100);

        if (chance < 15)
        {
            player.injured = true;
            player.injuryType = GetRandomInjury();
            player.recoveryDays = Random.Range(3, 30);

            Debug.Log(
                playerName + " sofreu uma lesão: " +
                player.injuryType
            );
        }
    }


    string GetRandomInjury()
    {
        string[] injuries =
        {
            "Dor muscular",
            "Entorse",
            "Contusão",
            "Lesão no joelho",
            "Cansaço extremo"
        };

        return injuries[Random.Range(0, injuries.Length)];
    }


    public void AdvanceDay()
    {
        foreach (PlayerInjury player in players)
        {
            if (player.injured)
            {
                player.recoveryDays--;

                if (player.recoveryDays <= 0)
                {
                    player.injured = false;
                    player.injuryType = "";
                    player.recoveryDays = 0;

                    Debug.Log(
                        player.playerName +
                        " voltou aos treinos!"
                    );
                }
            }
        }
    }


    public bool IsAvailable(string playerName)
    {
        PlayerInjury player = players.Find(p => p.playerName == playerName);

        if (player == null)
            return false;

        return !player.injured;
    }
}
