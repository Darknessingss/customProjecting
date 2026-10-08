using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(AudioConfigSO))]
public class AudioSOEditor : Editor
{
    private enum ViewMode { None, List, Text }
    private ViewMode _mode = ViewMode.None;

    public override void OnInspectorGUI()
    {
        var so = (AudioConfigSO)target;

        serializedObject.Update();

        EditorGUILayout.PropertyField(
            serializedObject.FindProperty("id"),
            new GUIContent("ID"));

        EditorGUILayout.PropertyField(
            serializedObject.FindProperty("contentType"),
            new GUIContent("Тип контента"));

        EditorGUILayout.Space(8);

        EditorGUILayout.BeginHorizontal();

        if (GUILayout.Button("Показать лист"))
            _mode = ViewMode.List;

        if (GUILayout.Button("Показать текст"))
            _mode = ViewMode.Text;

        if (GUILayout.Button("Скрыть всё"))
            _mode = ViewMode.None;

        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(8);

        switch (_mode)
        {
            case ViewMode.List:
                DrawActiveList(so);
                break;

            case ViewMode.Text:
                EditorGUILayout.LabelField("Текст панели:", EditorStyles.boldLabel);
                EditorGUILayout.PropertyField(
                    serializedObject.FindProperty("longText"),
                    GUIContent.none,
                    true);
                break;

            case ViewMode.None:
                break;
        }

        serializedObject.ApplyModifiedProperties();
    }

    private void DrawActiveList(AudioConfigSO so)
    {
        string propName;
        string header;

        switch (so.contentType)
        {
            case AudioContentType.Dangerous:
                propName = "dangerousList";
                header = "Лист: Опасный контент";
                break;
            case AudioContentType.Friendly:
                propName = "friendlyList";
                header = "Лист: Дружелюбный контент";
                break;
            case AudioContentType.Neutral:
            default:
                propName = "neutralList";
                header = "Лист: Нейтральный контент";
                break;
        }

        EditorGUILayout.LabelField(header, EditorStyles.boldLabel);

        var listProp = serializedObject.FindProperty(propName);
        EditorGUILayout.PropertyField(listProp, true);
    }
}