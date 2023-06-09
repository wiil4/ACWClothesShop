using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
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

    [Header("UI Coins")]
    [SerializeField] GameObject _coinsHandlerUI;

    [Header("Audio Clips")]
    [SerializeField] AudioClip _coinsClip;
    [SerializeField] AudioClip _buttonClip;

    void Start()
    {             
        SetClickEvents();
        ShowPurchaseItemsList();
    }

    private void GenerateListOfItems(ItemData itemsData, Transform itemsContentTransform)
    {
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
                
                if(!string.IsNullOrEmpty(itemsData.GetShopperName()))
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
        _closeShopButton.onClick.AddListener(CloseShop);
        _buyListButton.onClick.AddListener(ShowPurchaseItemsList);
        _sellListButton.onClick.AddListener(ShowSellItemsList);
    }

    public void ShowPurchaseItemsList()
    {
        _purchaseItemsList.SetActive(true);
        GameManager.instance.PlaySoundClip(_buttonClip);
        GenerateListOfItems(_shopItemsData, _purchaseItemsContent);
        _sellItemsList.SetActive(false);
    }
    private void ShowSellItemsList()
    {
        _sellItemsList.SetActive(true);
        GameManager.instance.PlaySoundClip(_buttonClip);
        GenerateListOfItems(_playerItemsData, _sellItemsContent);
        _purchaseItemsList.SetActive(false);
    }  

    public void OpenShop()
    {
        gameObject.SetActive(true);
        _coinsHandlerUI.SetActive(true);
        ShowPurchaseItemsList();
        GameManager.instance.CanPlay = false;
    }
    public void CloseShop()
    {
        gameObject.SetActive(false);
        _coinsHandlerUI.SetActive(false);
        GameManager.instance.PlaySoundClip(_buttonClip);
        GameManager.instance.CanPlay = true;
    }

    private void SellItem(Item itemData)
    {
        _playerItemsData.RemoveItem(itemData);
        GameManager.instance.SellItem(itemData.Price);
        GameManager.instance.PlaySoundClip(_coinsClip);
        GenerateListOfItems(_playerItemsData, _sellItemsContent);
    }
    private void PurchaseItem(Item itemData)
    {
        if(GameManager.instance.CheckCanBuyItems(itemData.Price))
        {
            _playerItemsData.AddItem(itemData);
            GameManager.instance.PlaySoundClip(_coinsClip);
            GameManager.instance.PurchaseItem(itemData.Price);
        }        
    }

    private void OnEnable()
    {
        _coinsHandlerUI.SetActive(true);
    }

    private void OnDisable()
    {
        _coinsHandlerUI.SetActive(false);
    }
}
