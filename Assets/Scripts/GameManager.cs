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
        HidePanels();
    }

    private void HidePanels()
    {
        _playerItemsUI.gameObject.SetActive(false);
        _shopItemsUI.gameObject.SetActive(false);
    }

    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            CanPlay = !CanPlay;
            _playerItemsUI.gameObject.SetActive(!CanPlay);
            _playerItemsUI.FillGrid();
        }
    }

    public void PurchaseItem(int price)
    {
        _currentCoins -= price;
        Mathf.Clamp(_currentCoins, 0, _maxCoins);
        _coinsHandlerUI.SetCurrentCoins(_currentCoins);
    }
    public void SellItem(int price)
    {
        _currentCoins += price;
        Mathf.Clamp(_currentCoins, 0, _maxCoins);
        _coinsHandlerUI.SetCurrentCoins(_currentCoins);
    }
}
