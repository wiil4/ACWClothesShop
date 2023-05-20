using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinsHandlerUI : MonoBehaviour
{
    [SerializeField] TMP_Text _currentCoins;

    public void SetCurrentCoins(int currentCoins)
    {
        _currentCoins.text = currentCoins.ToString();
    }
}
