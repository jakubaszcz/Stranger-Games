using System;
using UnityEngine;

public static class GameSignals
{
    public static Action OnCoinPicked;
    public static Action<int> OnCoinsChanged;
}
