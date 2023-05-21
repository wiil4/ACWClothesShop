using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemsUI : MonoBehaviour
{
    [Header("Main PlayerItemsUI")]
    [SerializeField] Button _closeButton;

    [Header("Player Grid Parameters")]
    [SerializeField] GridLayoutGroup _playerItemsGroup;
    [SerializeField] GameObject _playerItemPrefab;
    [SerializeField] GameObject _emptyList;

    [SerializeField] ItemData _playerItemsData;

    [Header("UI Coins")]
    [SerializeField] GameObject _coinsHandlerUI;

    void Start()
    {
        FillGrid();
        SetClickEvents();
    }

    private void SetClickEvents()
    {
        _closeButton.onClick.AddListener(CloseItemsPanel);
    }

    public void FillGrid()
    {
        if(_playerItemsData.CountItems()<=0)
        {            
            ClearGrid();
            _playerItemsGroup.gameObject.SetActive(false);
            _emptyList.SetActive(true);
            return;
        }

        _emptyList.SetActive(false);
        _playerItemsGroup.gameObject.SetActive(true);
        ClearGrid();
        for(int i = 0; i < _playerItemsData.CountItems(); i++)
        {
            Item newItem = _playerItemsData.GetItem(i);
            PlayerClothesItemUI playerItem = Instantiate(_playerItemPrefab, _playerItemsGroup.transform).GetComponent<PlayerClothesItemUI>();

            playerItem.SetItemImage(newItem.Image);
            playerItem.ChangeItem(newItem, ChangeItem);
        }
    }

    private void ClearGrid()
    {
        foreach(Transform child in _playerItemsGroup.transform)
        {
            Destroy(child.gameObject);
        }
    }

    private void ChangeItem(Item item)
    {
        Debug.Log("setPlayerItem" + item.Image.name);
    }

    public void CloseItemsPanel()
    {
        gameObject.SetActive(false);
        _coinsHandlerUI.SetActive(false);
        GameManager.instance.CanPlay = true;
    }

    public int CountPlayerItems()
    {
        return _playerItemsData.CountItems();
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
