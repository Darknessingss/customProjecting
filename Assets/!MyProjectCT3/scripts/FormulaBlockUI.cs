using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormulaBlockUI : MonoBehaviour
{
    private enum FormulaType { Kinetic, Potential }

    private static readonly Color NormalColor = Color.green;
    private static readonly Color ErrorColor = Color.red;

    [Header("Data")]
    [SerializeField] private FormulaType formulaType;
    [SerializeField] private FormulaViewData formulaViewData;
    [SerializeField] private ConstantsData constantsData;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI formulaText;
    [SerializeField] private TMP_InputField input1;
    [SerializeField] private TMP_InputField input2;
    [SerializeField] private Button calculateButton;
    [SerializeField] private TextMeshProUGUI resultText;

    private void Start()
    {
        formulaText.text = formulaType == FormulaType.Kinetic
            ? formulaViewData.KineticEnergyFormula
            : formulaViewData.PotentialEnergyFormula;

        input1.onValueChanged.AddListener(UpdateButtonState);
        input2.onValueChanged.AddListener(UpdateButtonState);
        calculateButton.onClick.AddListener(OnCalculate);

        SetResult(string.Empty, NormalColor);
        UpdateButtonState();
    }

    private void UpdateButtonState(string _ = null)
    {
        calculateButton.interactable =
            !string.IsNullOrWhiteSpace(input1.text) &&
            !string.IsNullOrWhiteSpace(input2.text);
    }

    private void OnCalculate()
    {
        if (!float.TryParse(input1.text, out float v1) ||
            !float.TryParse(input2.text, out float v2))
        {
            SetResult("Error", ErrorColor);
            return;
        }

        float result = formulaType == FormulaType.Kinetic
            ? PhysicsCalculator.CalculateKineticEnergy(v1, v2)
            : PhysicsCalculator.CalculatePotentialEnergy(v1, v2, constantsData.Gravity);

        if (!float.IsFinite(result))
        {
            SetResult("Error", ErrorColor);
            return;
        }

        SetResult(result.ToString("F2"), NormalColor);
    }

    private void SetResult(string text, Color color)
    {
        resultText.text = text;
        resultText.color = color;
    }
}