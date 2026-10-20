using System;
using UnityEngine;

public class Inventory : MonoSingleton<Inventory>
{
    public event Action OnChanged;

    public int CoinValueLevel { get; private set; } = 0;
    public int SpawnCountLevel { get; private set; } = 0;
    public float PassiveIncome { get; private set; } = 0f;
    public int MagnetLevel { get; private set; } = 0;

    public int CoinValueCost => 10 + CoinValueLevel * 2;
    public int SpawnCountCost => 8 + SpawnCountLevel * 2;
    public int PassiveCost => 20 + Mathf.RoundToInt(PassiveIncome * 10f) * 2;
    public int MagnetCost => 25 + MagnetLevel * 2;

    public bool BuyCoinValue()
    {
        if (!WalletManager.Instance.TrySpend(CoinValueCost)) 
            return false;
        CoinValueLevel++;
        OnChanged?.Invoke();
        return true;
    }

    public bool BuySpawnCount()
    {
        if (!WalletManager.Instance.TrySpend(SpawnCountCost)) 
            return false;
        SpawnCountLevel++;
        OnChanged?.Invoke();
        return true;
    }

    public bool BuyPassive()
    {
        if (!WalletManager.Instance.TrySpend(PassiveCost)) 
            return false;
        PassiveIncome += 0.1f;
        OnChanged?.Invoke();
        return true;
    }

    public bool BuyMagnet()
    {
        if (!WalletManager.Instance.TrySpend(MagnetCost)) 
            return false;
        MagnetLevel++;
        OnChanged?.Invoke();
        return true;
    }
}