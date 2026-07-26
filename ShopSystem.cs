using System.Collections.Generic;
using UnityEngine;

public class ShopSystem : MonoBehaviour
{
    [System.Serializable]
    public class ShopItem
    {
        public string itemName;
        public string itemType;
        public int price;
        public bool purchased;
    }


    public List<ShopItem> items = new List<ShopItem>();

    public int coins = 5000;


    void Start()
    {
        CreateShop();
    }


    void CreateShop()
    {
        items.Add(new ShopItem
        {
            itemName = "Uniforme Azul",
            itemType = "Camisa",
            price = 1000
        });

        items.Add(new ShopItem
        {
            itemName = "Bola Oficial",
            itemType = "Bola",
            price = 1500
        });

        items.Add(new ShopItem
        {
            itemName = "Estádio Melhorado",
            itemType = "Clube",
            price = 10000
        });
    }


    public void BuyItem(int index)
    {
        if (index < 0 || index >= items.Count)
            return;


        ShopItem item = items[index];


        if (item.purchased)
        {
            Debug.Log("Você já possui esse item.");
            return;
        }


        if (coins >= item.price)
        {
            coins -= item.price;
            item.purchased = true;

            Debug.Log(
                "Comprado: " +
                item.itemName
            );
        }
        else
        {
            Debug.Log("Moedas insuficientes!");
        }
    }


    public void ShowShop()
    {
        foreach (ShopItem item in items)
        {
            Debug.Log(
                item.itemName +
                " - Preço: " +
                item.price +
                " - " +
                (item.purchased ? "Comprado" : "Disponível")
            );
        }
    }
}
