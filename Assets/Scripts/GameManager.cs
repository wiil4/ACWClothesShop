using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool CanPlay { get; set; }

    [Header("GUI References")]
    [SerializeField] PlayerItemsUI _playerItemsUI;
    [SerializeField] ShopUI _shopItemsUI;
    [SerializeField] CoinsHandlerUI _coinsHandlerUI;

    [Header("Coins")]
    [SerializeField] int _maxCoins = 100000;
    int _currentCoins;

    [Header("Player Items Permited")]
    [SerializeField] int _maxPlayerItems = 15;
    int _currentPlayerItems;
    bool _canBuy;

    [Header("Player Clothes")]
    [SerializeField] ClothesManager _clothesManager;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
        CanPlay = true;
        _currentCoins = _maxCoins;
        _coinsHandlerUI.SetCurrentCoins(_currentCoins);
        _currentPlayerItems = _playerItemsUI.CountPlayerItems();
        HidePanels();
    }

    private void HidePanels()
    {
        _playerItemsUI.gameObject.SetActive(false);
        _shopItemsUI.gameObject.SetActive(false);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            CanPlay = !CanPlay;
            _playerItemsUI.gameObject.SetActive(!CanPlay);
            _playerItemsUI.FillGrid();
        }
    }

    public void PurchaseItem(int price)
    {
        _currentCoins -= price;
        _currentPlayerItems++;
        _coinsHandlerUI.SetCurrentCoins(_currentCoins);            
    }  

    public void SellItem(int price)
    {
        _currentCoins += price;
        _currentPlayerItems--;
        _coinsHandlerUI.SetCurrentCoins(_currentCoins);
    }
    public bool CheckCanBuyItems(int price)
    {
        if (_currentCoins < 0)
        {
            _currentCoins = 0;
            _canBuy = false;
        }
        else if (_currentPlayerItems >= _maxPlayerItems)
            _canBuy = false;
        else
            _canBuy = true;

        if (_currentCoins - price < 0)
            _canBuy = false;

        return _canBuy;
    }

    public void ChangeClothes(BodyPart bodyidentifier, ItemClass itemType)
    {
        _clothesManager.SetClothes(bodyidentifier, itemType);
    }
}
