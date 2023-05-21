using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopInteraction : MonoBehaviour
{
    bool _playerDetected;

    [Header("Dialog Canvas")]
    [SerializeField] GameObject _pop;

    [Header("Character Shop Panel")]
    [SerializeField] ShopUI _shopPanel;

    
    void Start()
    {
        _playerDetected = false;
    }

    
    void Update()
    {
        if(_playerDetected)
        {
            ShowDialogButton();
        }
        _pop.SetActive(_playerDetected);
    }

    private void ShowDialogButton()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            _shopPanel.gameObject.SetActive(true);
            _shopPanel.ShowPurchaseItemsList();
            GameManager.instance.CanPlay = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerDetected = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            _playerDetected = false;
        }
    }
}
