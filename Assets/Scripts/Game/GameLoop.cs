using System;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    private GameStatistics gameStatistics;

    private void Awake()
    {
        gameStatistics = GetComponent<GameStatistics>();
    }

    private void GameOver(Condition condition)
    {
        Time.timeScale = 0;

        switch (condition)
        {
            case Condition.Lose:
                break;
            case Condition.Win:
                break;
        }
    } 
    private void CheckCoinsAmount(int amount)
    {
        if (amount >= gameStatistics.GetCoins())
        {
            GameSignals.OnGameOver?.Invoke(Condition.Win);
        }
    }
    private void OnEnable()
    {
        GameSignals.OnCoinsChanged += CheckCoinsAmount;
        GameSignals.OnGameOver += GameOver;
    }
    
    private void OnDisable()
    {
        GameSignals.OnCoinsChanged -= CheckCoinsAmount;
        GameSignals.OnGameOver -= GameOver;
    }
}
