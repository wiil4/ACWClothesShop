using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Item
{
    public Sprite Image;
    public string Name;
    public int Price;
    public BodyPart BodyPartIdentifier;
    public ItemClass ItemClassIdentifier;
}
