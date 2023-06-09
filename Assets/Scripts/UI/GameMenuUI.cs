using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMenuUI : MonoBehaviour
{
    [SerializeField] GameObject _gameMenuUI;
    [SerializeField] Button _openMenuButton;
    [SerializeField] Button _continueGameButton;
    [SerializeField] Button _exitGameButton;

    [Header("AudioClips")]
    [SerializeField] AudioClip _buttonClip;

    void Start()
    {
        _openMenuButton.onClick.AddListener(OpenGameMenu);
        _continueGameButton.onClick.AddListener(CloseGameMenu);
        _exitGameButton.onClick.AddListener(ExitGame);        
    }


    private void OpenGameMenu()
    {
        _gameMenuUI.SetActive(true);
        GameManager.instance.PlaySoundClip(_buttonClip);
        GameManager.instance.CanPlay = false;
    }
    private void CloseGameMenu()
    {
        _gameMenuUI.SetActive(false);
        GameManager.instance.PlaySoundClip(_buttonClip);
        GameManager.instance.CanPlay = true;
    }
    private void ExitGame()
    {
        GameManager.instance.PlaySoundClip(_buttonClip);
        Application.Quit();
    }
}
