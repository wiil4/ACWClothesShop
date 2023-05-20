using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [Header("Main Shop Panel")]
    [SerializeField] GameObject _shopUI;

    [Header("UI Navigation Buttons")]
    [SerializeField] Button _closeShopButton;
    [SerializeField] Button _buyListButton;
    [SerializeField] Button _sellListButton;

    [Header("UI Buy/Sell Panels")]
    [SerializeField] GameObject _buyItemsList;
    [SerializeField] GameObject _sellItemsList;


    void Start()
    {
        _buyItemsList.SetActive(true);
        _sellItemsList.SetActive(false);
        CloseShop();
        SetClickEvents();
    }

    private void SetClickEvents()
    {
        _closeShopButton.onClick.AddListener(CloseShopPanel);
        _buyListButton.onClick.AddListener(ShowBuyItemsList);
        _sellListButton.onClick.AddListener(ShowSellItemsList);
    }

    private void ShowSellItemsList()
    {
        _buyItemsList.SetActive(false);
        _sellItemsList.SetActive(true);
    }

    private void ShowBuyItemsList()
    {
        _buyItemsList.SetActive(true);
        _sellItemsList.SetActive(false);
    }

    private void CloseShopPanel()
    {
        CloseShop();
    }

    private void CloseShop()
    {
        _shopUI.SetActive(false);
    }

}
