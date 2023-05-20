using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerClothesItemUI : MonoBehaviour
{
    [SerializeField] Image _itemImage;    

    public void SetItemImage(Sprite reference)
    {
        _itemImage.sprite = reference;
    }
}
