using System;

public class Model
{
    public event Action<int> OnHealthChanged;
    public event Action<int> OnScoreChanged;

    private int _health;
    private int _score;

    public int Health
    {
        get => _health;
        private set
        {
            _health = value;
            OnHealthChanged?.Invoke(_health);
        }
    }

    public int Score
    {
        get => _score;
        private set
        {
            _score = value;
            OnScoreChanged?.Invoke(_score);
        }
    }

    public void Initialize(int startHealth)
    {
        Health = startHealth;
        Score = 0;
    }

    public void ApplyDamage(int amount) => Health = Math.Max(0, Health - amount);

    public void AddScore(int amount) => Score += amount;
}