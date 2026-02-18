using UnityEngine;

public class PlayerStatistics : MonoBehaviour
{
    // Player statistics
    private int _coins;
    
    public int GetCoins() { return _coins; }
    
    // Add coins function signal
    void AddCoin()
    {
        GameSignals.OnCoinsChanged?.Invoke(++_coins);
    }
    
    // Enable signals
    void OnEnable()
    {
        GameSignals.OnCoinPicked += AddCoin;
    }
    
    // Disable signals
    void OnDisable()
    {
        GameSignals.OnCoinPicked -= AddCoin;
    }
}
