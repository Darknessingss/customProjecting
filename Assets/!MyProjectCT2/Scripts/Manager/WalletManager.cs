using System;
using UnityEngine;

public class WalletManager : MonoSingleton<WalletManager>
{
    public event Action<int> OnCoinsChanged;

    [SerializeField] private int coins;

    public int Coins => coins;

    public void Add(int amount)
    {
        coins += amount;
        OnCoinsChanged?.Invoke(coins);
    }

    public bool TrySpend(int amount)
    {
        if (coins < amount) return false;
        coins -= amount;
        OnCoinsChanged?.Invoke(coins);
        return true;
    }
}