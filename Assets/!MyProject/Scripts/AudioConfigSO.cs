using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AudioConfig", menuName = "Audio/AudioConfig")]
public class AudioConfigSO : ScriptableObject
{
    [Header("Идентификатор")]
    public string id = "unique_id_001";

    [Header("Тип аудиоконтента")]
    public AudioContentType contentType = AudioContentType.Neutral;


    [Header("Листы аудио (по типу контента)")]
    public List<AudioEntry> dangerousList = new List<AudioEntry>();
    public List<AudioEntry> friendlyList = new List<AudioEntry>();
    public List<AudioEntry> neutralList = new List<AudioEntry>();

    [Header("Текст для панели")]
    [TextArea(5, 15)]
    public string longText = "Введите длинный текст...";

    public List<AudioEntry> GetActiveList()
    {
        switch (contentType)
        {
            case AudioContentType.Dangerous: return dangerousList;
            case AudioContentType.Friendly: return friendlyList;
            case AudioContentType.Neutral: return neutralList;
            default: return neutralList;
        }
    }
}
