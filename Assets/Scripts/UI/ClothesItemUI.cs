using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ClothesItemUI : MonoBehaviour
{
    [SerializeField] Image _itemImage;
    [SerializeField] TMP_Text _itemName;
    [SerializeField] TMP_Text _itemPrice;
    [SerializeField] Button _purchaseItemButton;

    public void SetItemPosition(Vector2 pos)
    {
        GetComponent<RectTransform>().anchoredPosition += pos;
    }
    public void SetItemImage(Sprite reference)
    {
        _itemImage.sprite = reference;
    }

    public void SetItemName(string name)
    {
        _itemName.text = name;
    }

    public void SetItemPrice(int price)
    {
        _itemPrice.text = price.ToString();
    }

    public void SetBuySellAction(UnityAction action)
    {
        _purchaseItemButton.onClick.RemoveAllListeners();
        _purchaseItemButton.onClick.AddListener(()=> action.Invoke());
    }

}
