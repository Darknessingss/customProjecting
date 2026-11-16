using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class View : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _healthText;
    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _scoreButton;

    public Button DamageButton => _damageButton;
    public Button ScoreButton => _scoreButton;

    public void UpdateHealth(int health)
    {
        if (_healthText != null) _healthText.text = $"HP: {health}";
    }

    public void UpdateScore(int score)
    {
        if (_scoreText != null) _scoreText.text = $"Score: {score}";
    }
}