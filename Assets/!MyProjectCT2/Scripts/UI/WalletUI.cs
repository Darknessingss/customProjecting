using TMPro;
using UnityEngine;

public class WalletUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI coinsText;

    private void Start()
    {
        WalletManager.Instance.OnCoinsChanged += UpdateText;
        UpdateText(WalletManager.Instance.Coins);
    }

    private void OnDisable()
    {
        if (WalletManager.Instance != null)
            WalletManager.Instance.OnCoinsChanged -= UpdateText;
    }

    private void UpdateText(int value) => coinsText.text = $"{value}";
}