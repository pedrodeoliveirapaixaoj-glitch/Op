using System.Collections.Generic;
using UnityEngine;

public class CardSystem : MonoBehaviour
{
    [System.Serializable]
    public class PlayerCard
    {
        public string playerName;
        public int yellowCards;
        public bool redCard;
        public bool suspended;
    }

    public List<PlayerCard> players = new List<PlayerCard>();


    public void GiveYellowCard(int playerIndex)
    {
        if (!CheckPlayer(playerIndex))
            return;

        players[playerIndex].yellowCards++;

        Debug.Log(
            players[playerIndex].playerName +
            " recebeu cartão amarelo 🟨"
        );

        if (players[playerIndex].yellowCards >= 2)
        {
            GiveRedCard(playerIndex);
        }
    }


    public void GiveRedCard(int playerIndex)
    {
        if (!CheckPlayer(playerIndex))
            return;

        players[playerIndex].redCard = true;
        players[playerIndex].suspended = true;

        Debug.Log(
            players[playerIndex].playerName +
            " recebeu cartão vermelho 🟥"
        );
    }


    public void RemoveSuspension(int playerIndex)
    {
        if (!CheckPlayer(playerIndex))
            return;

        players[playerIndex].suspended = false;
        players[playerIndex].yellowCards = 0;
        players[playerIndex].redCard = false;

        Debug.Log(
            "Suspensão removida de " +
            players[playerIndex].playerName
        );
    }


    bool CheckPlayer(int index)
    {
        return index >= 0 && index < players.Count;
    }
}
