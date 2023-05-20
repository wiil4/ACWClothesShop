using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("Main Shop Panel")]
    [SerializeField] GameObject _shopUI;

    [Header("Shop Items Parameters")]
    [SerializeField] float _spaceBetweenItems = 2f;
    [SerializeField] GameObject _shopItemPrefab;    
    float _itemHeight;

    [SerializeField] ItemData _shopItemsData;
    [SerializeField] ItemData _playerItemsData;

    [Header("UI Navigation Buttons")]
    [SerializeField] Button _closeShopButton;
    [SerializeField] Button _buyListButton;
    [SerializeField] Button _sellListButton;

    [Header("UI Store Items")]
    [SerializeField] GameObject _purchaseItemsList;
    [SerializeField] Transform _purchaseItemsContent;    

    [Header("UI Player Items")]
    [SerializeField] GameObject _sellItemsList;
    [SerializeField] Transform _sellItemsContent;

    void Start()
    {     
        GenerateListOfItems(_shopItemsData, _purchaseItemsContent);
        SetClickEvents();
    }

    private void GenerateListOfItems(ItemData itemsData, Transform itemsContentTransform)
    {
        //TODO, ERASE ALL CHILDREN IN STARTING 
        for(int i = 1; i< itemsContentTransform.childCount; i++)
        {
            Destroy(itemsContentTransform.GetChild(i).gameObject);
        }
        if (itemsData.CountItems() > 0)
        {
            _itemHeight = itemsContentTransform.GetChild(0).GetComponent<RectTransform>().sizeDelta.y;
            itemsContentTransform.GetChild(0).gameObject.SetActive(false);

            for (int i = 0; i < itemsData.CountItems(); i++)
            {
                Item newItem = itemsData.GetItem(i);
                ClothesItemUI clothesItem = Instantiate(_shopItemPrefab, itemsContentTransform).GetComponent<ClothesItemUI>();

                clothesItem.SetItemPosition(Vector2.down * i * (_itemHeight + _spaceBetweenItems));

                clothesItem.SetItemImage(newItem.Image);
                clothesItem.SetItemName(newItem.Name);
                clothesItem.SetItemPrice(newItem.Price);
                
                if(itemsData.GetShopperName()!="")
                {
                    clothesItem.SetBuySellAction(newItem, PurchaseItem);
                }
                else
                {
                    clothesItem.SetBuySellAction(newItem, SellItem);
                }
                

                itemsContentTransform.GetComponent<RectTransform>().sizeDelta = Vector2.up * (_itemHeight + _spaceBetweenItems) * itemsData.CountItems();
            }
        }
        else
        {
            itemsContentTransform.GetChild(0).gameObject.SetActive(true);
        }
    }
    private void SetClickEvents()
    {
        _closeShopButton.onClick.AddListener(CloseShopPanel);
        _buyListButton.onClick.AddListener(ShowBuyItemsList);
        _sellListButton.onClick.AddListener(ShowSellItemsList);
    }

    private void ShowBuyItemsList()
    {
        _purchaseItemsList.SetActive(true);
        GenerateListOfItems(_shopItemsData, _purchaseItemsContent);
        _sellItemsList.SetActive(false);
    }
    private void ShowSellItemsList()
    {
        _purchaseItemsList.SetActive(false);
        GenerateListOfItems(_playerItemsData, _sellItemsContent);
        _sellItemsList.SetActive(true);
    }  

    private void CloseShopPanel()
    {
        CloseShop();
    }

    private void CloseShop()
    {
        _shopUI.SetActive(false);
    }

    private void SellItem(Item itemData)
    {
        _playerItemsData.RemoveItem(itemData);
        GenerateListOfItems(_playerItemsData, _sellItemsContent);
    }
    private void PurchaseItem(Item itemData)
    {
        _playerItemsData.AddItem(itemData);
    }
}
