using System.Collections.Generic;
using UnityEngine;

public class TransferMarket : MonoBehaviour
{
    [System.Serializable]
    public class MarketPlayer
    {
        public string name;
        public int overall;
        public int price;
    }

    public List<MarketPlayer> playersForSale = new List<MarketPlayer>();

    public int coins = 100000;

    void Start()
    {
        CreateMarket();
    }

    void CreateMarket()
    {
        playersForSale.Add(new MarketPlayer
        {
            name = "Atacante Lendário",
            overall = 90,
            price = 50000
        });

        playersForSale.Add(new MarketPlayer
        {
            name = "Meio Campista Elite",
            overall = 85,
            price = 30000
        });

        playersForSale.Add(new MarketPlayer
        {
            name = "Defensor Forte",
            overall = 82,
            price = 20000
        });
    }

    public void BuyPlayer(int index)
    {
        if (index < 0 || index >= playersForSale.Count)
            return;

        MarketPlayer player = playersForSale[index];

        if (coins >= player.price)
        {
            coins -= player.price;

            Debug.Log("Você contratou: " + player.name);

            playersForSale.RemoveAt(index);
        }
        else
        {
            Debug.Log("Moedas insuficientes!");
        }
    }

    public void SellPlayer(string playerName, int value)
    {
        coins += value;

        Debug.Log("Jogador vendido: " + playerName);
        Debug.Log("Você recebeu: " + value + " moedas");
    }
}
