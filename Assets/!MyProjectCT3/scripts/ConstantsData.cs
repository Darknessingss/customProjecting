using UnityEngine;

[CreateAssetMenu(fileName = "ConstantsData", menuName = "Physics/Constants Data")]
public class ConstantsData : ScriptableObject
{
    [SerializeField] private float gravity = 9.8f;

    public float Gravity => gravity;
}