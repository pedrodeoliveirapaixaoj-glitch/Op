using System.Collections.Generic;
using UnityEngine;

public class PackOpening : MonoBehaviour
{
    [System.Serializable]
    public class PlayerCard
    {
        public string playerName;
        public string position;
        public int overall;
        public string rarity;
    }

    public List<PlayerCard> availablePlayers = new List<PlayerCard>();

    public int packCost = 1000;
    public int coins = 5000;

    void Start()
    {
        CreatePlayerPool();
    }

    void CreatePlayerPool()
    {
        availablePlayers.Add(new PlayerCard
        {
            playerName = "Atacante Rápido",
            position = "ST",
            overall = 85,
            rarity = "Ouro"
        });

        availablePlayers.Add(new PlayerCard
        {
            playerName = "Meio Campista Craque",
            position = "CM",
            overall = 88,
            rarity = "Elite"
        });

        availablePlayers.Add(new PlayerCard
        {
            playerName = "Defensor Lendário",
            position = "CB",
            overall = 90,
            rarity = "Lendário"
        });
    }

    public PlayerCard OpenPack()
    {
        if (coins < packCost)
        {
            Debug.Log("Você não tem moedas suficientes!");
            return null;
        }

        coins -= packCost;

        int randomIndex = Random.Range(0, availablePlayers.Count);

        PlayerCard reward = availablePlayers[randomIndex];

        Debug.Log("Você conseguiu: " + reward.playerName +
                  " | " + reward.rarity +
                  " | Overall: " + reward.overall);

        return reward;
    }
}
