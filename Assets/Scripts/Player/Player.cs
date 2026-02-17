using UnityEngine;

public class Player : MonoBehaviour
{
    // Player statistics
    private int _coins = 0;
    
    // public int GetCoins() { return _coins; }
    
    // Add coins function signal
    void AddCoin() { _coins++; }
    
    // Enable signals
    void OnEnable()
    {
        GameSignals.OnCoin += AddCoin;
    }
    
    // Disable signals
    void OnDisable()
    {
        GameSignals.OnCoin += AddCoin;
    }
}
