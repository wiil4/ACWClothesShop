using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool CanPlay { get; set; }

    [Header("GUIReferences")]
    [SerializeField] PlayerItemsUI _playerItemsUI;
    [SerializeField] ShopUI _shopItemsUI;


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
}
