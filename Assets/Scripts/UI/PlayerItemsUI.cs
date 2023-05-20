using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerItemsUI : MonoBehaviour
{
    [Header("Player Grid Parameters")]
    [SerializeField] GridLayoutGroup _playerItemsGroup;
    [SerializeField] GameObject _playerItemPrefab;
    [SerializeField] GameObject _emptyList;

    [SerializeField] ItemData _playerItemsData;


    void Start()
    {
        FillGrid();
    }

    void Update()
    {
        
    }

    private void FillGrid()
    {
        if(_playerItemsData.CountItems()<=0)
        {
            _playerItemsGroup.gameObject.SetActive(false);
            return;
        }

        _emptyList.SetActive(false);
        ClearGrid();
        for(int i = 0; i < _playerItemsData.CountItems(); i++)
        {
            Item playerItem = _playerItemsData.GetItem(i);

        }
        


    }

    private void ClearGrid()
    {
        foreach(Transform child in _playerItemsGroup.transform)
        {
            Destroy(child.gameObject);
        }
    }
}
