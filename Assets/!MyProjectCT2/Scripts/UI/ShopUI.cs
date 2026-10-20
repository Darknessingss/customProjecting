using TMPro;
using UnityEngine;

public class ShopUI : MonoBehaviour
{
    [Header("Тексты цен/уровней")]
    [SerializeField] private TextMeshProUGUI coinValueText;
    [SerializeField] private TextMeshProUGUI spawnCountText;
    [SerializeField] private TextMeshProUGUI passiveText;
    [SerializeField] private TextMeshProUGUI magnetText;

    private void Start()
    {
        Inventory.Instance.OnChanged += Refresh;
        Refresh();
    }

    private void OnDisable()
    {
        if (Inventory.Instance != null)
            Inventory.Instance.OnChanged -= Refresh;
    }

    private void Refresh()
    {
        var inv = Inventory.Instance;
        coinValueText.text = $"Стоимость монеты\n{inv.CoinValueCost} монет +1";
        spawnCountText.text = $"Спавн монет\n{inv.SpawnCountCost} монет +1";
        passiveText.text = $"Пассивный доход\n{inv.PassiveCost} монет +0.1/с";
        magnetText.text = $"Магнит\n{inv.MagnetCost} монет радиус +1.5";
    }

    public void BuyCoinValue() => Inventory.Instance.BuyCoinValue();
    public void BuySpawnCount() => Inventory.Instance.BuySpawnCount();
    public void BuyPassive() => Inventory.Instance.BuyPassive();
    public void BuyMagnet() => Inventory.Instance.BuyMagnet();
}