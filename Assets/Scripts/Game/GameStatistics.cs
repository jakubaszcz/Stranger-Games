using System;
using UnityEngine;

public class GameStatistics : MonoBehaviour
{
    [SerializeField] private Transform collectibles;
    
    private int _coins;

    public int GetCoins()
    {
        return _coins;
    }
    
    private void Awake()
    {
        if (collectibles == null) collectibles = transform.GetChild(0);
    }

    private void Start()
    {
        FetchCoins();
    }

    private void FetchCoins()
    {
        foreach (Transform c in collectibles) _coins++;
    }
}
