using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "General Items Data/New Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] string _shopperName = string.Empty;
    [SerializeField] List<Item> _itemsInventory = new List<Item>();

    public string GetShopperName()
    {
        return _shopperName;
    }
    public int CountItems()
    {
        return _itemsInventory.Count;
    }

    public void AddItem(Item newItem)
    {
        _itemsInventory.Add(newItem);
    }
    public void RemoveItem(Item item)
    {
        _itemsInventory.Remove(item);
    }

    public Item GetItem(int index)
    {
        return _itemsInventory[index];
    }
}
