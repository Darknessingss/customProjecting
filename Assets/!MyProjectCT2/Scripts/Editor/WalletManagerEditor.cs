using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(WalletManager))]
public class WalletManagerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        var wallet = (WalletManager)target;

        GUILayout.Space(10);
        GUILayout.Label("Отладка баланса", EditorStyles.boldLabel);

        if (GUILayout.Button("+10 монет")) wallet.Add(10);
        if (GUILayout.Button("−10 монет")) wallet.TrySpend(10);
    }
}