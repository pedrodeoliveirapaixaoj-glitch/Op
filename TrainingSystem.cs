using System.Collections.Generic;
using UnityEngine;

public class TrainingSystem : MonoBehaviour
{
    [System.Serializable]
    public class PlayerTraining
    {
        public string playerName;

        public int shooting;
        public int passing;
        public int speed;
        public int defending;
        public int overall;
    }

    public List<PlayerTraining> players = new List<PlayerTraining>();

    public void TrainShooting(int playerIndex)
    {
        if (!CheckPlayer(playerIndex))
            return;

        players[playerIndex].shooting += 2;
        UpdateOverall(playerIndex);

        Debug.Log(players[playerIndex].playerName + " melhorou o chute!");
    }


    public void TrainPassing(int playerIndex)
    {
        if (!CheckPlayer(playerIndex))
            return;

        players[playerIndex].passing += 2;
        UpdateOverall(playerIndex);

        Debug.Log(players[playerIndex].playerName + " melhorou o passe!");
    }


    public void TrainSpeed(int playerIndex)
    {
        if (!CheckPlayer(playerIndex))
            return;

        players[playerIndex].speed += 2;
        UpdateOverall(playerIndex);

        Debug.Log(players[playerIndex].playerName + " ficou mais rápido!");
    }


    public void TrainDefense(int playerIndex)
    {
        if (!CheckPlayer(playerIndex))
            return;

        players[playerIndex].defending += 2;
        UpdateOverall(playerIndex);

        Debug.Log(players[playerIndex].playerName + " melhorou a defesa!");
    }


    void UpdateOverall(int index)
    {
        PlayerTraining player = players[index];

        player.overall =
            (player.shooting +
            player.passing +
            player.speed +
            player.defending) / 4;

        if (player.overall > 99)
            player.overall = 99;
    }


    bool CheckPlayer(int index)
    {
        return index >= 0 && index < players.Count;
    }
}
