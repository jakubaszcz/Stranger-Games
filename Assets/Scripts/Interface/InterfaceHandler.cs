using System;
using UnityEngine;
using TMPro;

public class InterfaceHandler : MonoBehaviour
{
    [SerializeField] private GameStatistics gameStatistics;
    
    [SerializeField] private TMP_Text coinText;

    private void Start()
    {
        UpdateCoinText(0);
    }

    private void UpdateCoinText(int coins)
    {
        coinText.text = $"Coins found {coins}/{gameStatistics.GetCoins()}";
    }

    void OnEnable()
    {
        GameSignals.OnCoinsChanged += UpdateCoinText;
    }

    void OnDisable()
    {
        GameSignals.OnCoinsChanged -= UpdateCoinText;
    }
}
