using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [System.Serializable]
    public class Item
    {
        public string itemName;
        public string itemType;
        public int quantity;
    }

    public List<Item> items = new List<Item>();

    public void AddItem(string name, string type, int amount)
    {
        Item newItem = new Item();

        newItem.itemName = name;
        newItem.itemType = type;
        newItem.quantity = amount;

        items.Add(newItem);

        Debug.Log("Item adicionado: " + name);
    }

    public void RemoveItem(string name)
    {
        Item item = items.Find(i => i.itemName == name);

        if (item != null)
        {
            items.Remove(item);
            Debug.Log("Item removido: " + name);
        }
    }

    public bool HasItem(string name)
    {
        return items.Exists(i => i.itemName == name);
    }

    public void ShowInventory()
    {
        foreach (Item item in items)
        {
            Debug.Log(
                item.itemName + 
                " | Tipo: " + item.itemType +
                " | Quantidade: " + item.quantity
            );
        }
    }
}
