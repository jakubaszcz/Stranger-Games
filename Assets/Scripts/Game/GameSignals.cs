using System;
using UnityEngine;

public enum Condition
{
    Win,
    Lose
}
public static class GameSignals
{
    public static Action OnCoinPicked;
    public static Action<Condition> OnGameOver;
    public static Action<int> OnCoinsChanged;
}
