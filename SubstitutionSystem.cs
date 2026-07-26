using System.Collections.Generic;
using UnityEngine;

public class SubstitutionSystem : MonoBehaviour
{
    [System.Serializable]
    public class Player
    {
        public string playerName;
        public string position;
        public int stamina;
        public bool starter;
    }

    public List<Player> startingPlayers = new List<Player>();
    public List<Player> benchPlayers = new List<Player>();

    public int maxSubstitutions = 5;
    private int substitutionsMade = 0;


    public void MakeSubstitution(int starterIndex, int benchIndex)
    {
        if (substitutionsMade >= maxSubstitutions)
        {
            Debug.Log("Limite de substituições atingido!");
            return;
        }

        if (starterIndex < 0 || starterIndex >= startingPlayers.Count)
            return;

        if (benchIndex < 0 || benchIndex >= benchPlayers.Count)
            return;


        Player playerOut = startingPlayers[starterIndex];
        Player playerIn = benchPlayers[benchIndex];


        startingPlayers[starterIndex] = playerIn;
        benchPlayers[benchIndex] = playerOut;


        playerIn.starter = true;
        playerOut.starter = false;


        substitutionsMade++;

        Debug.Log(
            "Entrou: " + playerIn.playerName +
            " | Saiu: " + playerOut.playerName
        );
    }


    public void ReduceFatigue()
    {
        foreach (Player player in startingPlayers)
        {
            player.stamina -= 1;

            if (player.stamina < 0)
                player.stamina = 0;
        }

        Debug.Log("Jogadores ficaram cansados.");
    }


    public void RecoverBenchPlayers()
    {
        foreach (Player player in benchPlayers)
        {
            player.stamina += 5;

            if (player.stamina > 100)
                player.stamina = 100;
        }

        Debug.Log("Reservas recuperaram energia.");
    }


    public int GetRemainingSubstitutions()
    {
        return maxSubstitutions - substitutionsMade;
    }
}
