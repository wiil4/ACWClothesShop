using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewItemData", menuName = "General Items Data/New Item Data")]
public class ItemData : ScriptableObject
{
    [SerializeField] List<Item> _itemsInventory = new List<Item>();

    public void AddItem(Item newItem)
    {
        _itemsInventory.Add(newItem);
    }
    public void RemoveItem(Item item)
    {
        _itemsInventory.Remove(item);
    }
}
