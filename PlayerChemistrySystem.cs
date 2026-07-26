using System.Collections.Generic;
using UnityEngine;

public class PlayerChemistrySystem : MonoBehaviour
{
    [System.Serializable]
    public class Player
    {
        public string playerName;
        public string position;
        public int chemistry;
    }

    public List<Player> team = new List<Player>();

    public int teamChemistry;


    public void CalculateChemistry()
    {
        int total = 0;

        foreach (Player player in team)
        {
            total += player.chemistry;
        }

        if (team.Count > 0)
        {
            teamChemistry = total / team.Count;
        }

        Debug.Log("Entrosamento do time: " + teamChemistry);
    }


    public float GetAttackBonus()
    {
        if (teamChemistry >= 80)
            return 1.15f;

        if (teamChemistry >= 50)
            return 1.05f;

        return 1f;
    }


    public float GetDefenseBonus()
    {
        if (teamChemistry >= 80)
            return 1.15f;

        if (teamChemistry >= 50)
            return 1.05f;

        return 1f;
    }


    public void IncreaseChemistry(string playerName, int amount)
    {
        Player player = team.Find(p => p.playerName == playerName);

        if (player != null)
        {
            player.chemistry += amount;

            if (player.chemistry > 100)
                player.chemistry = 100;
        }

        CalculateChemistry();
    }
}
