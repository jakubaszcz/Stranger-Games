using System;
using UnityEngine;
using TMPro;

public class InterfaceHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text coinText;

    private void Start()
    {
        UpdateCoinText(0);
    }

    private void UpdateCoinText(int coins)
    {
        coinText.text = $"Coins found {coins}/0";
        Debug.Log(coins);
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
