using UnityEngine;

public class Player : MonoBehaviour
{

    private int _coins = 0;
    
    public int GetCoins() { return _coins; }
    
    void AddCoin() { _coins++; }
    
    void OnEnable()
    {
        GameSignals.OnCoin += AddCoin;
    }
    
    void OnDisable()
    {
        GameSignals.OnCoin += AddCoin;
    }
}
