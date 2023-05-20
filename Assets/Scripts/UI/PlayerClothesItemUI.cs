using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class PlayerClothesItemUI : MonoBehaviour
{
    [SerializeField] Image _itemImage;
    [SerializeField] Button _changeItemButton;

    public void SetItemImage(Sprite reference)
    {
        _itemImage.sprite = reference;
    }

    public void ChangeItem(Item item, UnityAction<Item> action)
    {
        _changeItemButton.onClick.RemoveAllListeners();
        _changeItemButton.onClick.AddListener(() => action.Invoke(item));
    }
}
