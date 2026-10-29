using UnityEngine;

[CreateAssetMenu(fileName = "FormulaViewData", menuName = "Physics/Formula View Data")]
public class FormulaViewData : ScriptableObject
{
    [SerializeField] private string kineticEnergyFormula = "E<sub>k</sub> = (m * v<sup>2</sup>) / 2";
    [SerializeField] private string potentialEnergyFormula = "E<sub>p</sub> = m * g * h";

    public string KineticEnergyFormula => kineticEnergyFormula;
    public string PotentialEnergyFormula => potentialEnergyFormula;
}