using System;
using UnityEngine;

public class PassiveIncome : MonoBehaviour
{
    private float _timer;

    private float temp;

    private void Update()
    {
        float income = Inventory.Instance.PassiveIncome;
        if (income <= 0f) 
            return;

        _timer += Time.deltaTime;
        while (_timer >= 1f)
        {
            _timer -= 1f;
            temp += income;
            if (temp > 0)
            {
                WalletManager.Instance.Add((int)temp);
                temp -= (int) temp;
            }
            
        }
    }
}