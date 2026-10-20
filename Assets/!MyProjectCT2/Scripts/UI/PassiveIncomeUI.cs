using TMPro;
using UnityEngine;

public class PassiveIncomeUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI passiveText;

    private void Update()
    {
        float income = Inventory.Instance.PassiveIncome;
        passiveText.text = income > 0f
            ? $"Пассив: {income:0.0}/с"
            : "Пассив: -";
    }
}