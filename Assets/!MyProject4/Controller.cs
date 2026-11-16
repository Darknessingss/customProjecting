using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private View _view;
    [SerializeField] private DamageStrategy _damagePrefab;
    [SerializeField] private ScoreStrategy _scorePrefab;
    [SerializeField] private Transform _poolParent;

    private Model _model;
    private ObjectPool<DamageStrategy> _damagePool;
    private ObjectPool<ScoreStrategy> _scorePool;

    private void Awake()
    {
        _damagePool = new ObjectPool<DamageStrategy>(_damagePrefab, 3, 10, _poolParent);
        _scorePool = new ObjectPool<ScoreStrategy>(_scorePrefab, 3, 10, _poolParent);

        _model = new Model();
        _model.OnHealthChanged += _view.UpdateHealth;
        _model.OnScoreChanged += _view.UpdateScore;
        _model.Initialize(100);
    }

    private void OnEnable()
    {
        _view.DamageButton.onClick.AddListener(OnDamageClicked);
        _view.ScoreButton.onClick.AddListener(OnScoreClicked);
    }

    private void OnDisable()
    {
        _view.DamageButton.onClick.RemoveListener(OnDamageClicked);
        _view.ScoreButton.onClick.RemoveListener(OnScoreClicked);
    }

    private void OnDamageClicked()
    {
        var strategy = _damagePool.Get();
        strategy.Execute(_model);
        _damagePool.Return(strategy);
    }

    private void OnScoreClicked()
    {
        var strategy = _scorePool.Get();
        strategy.Execute(_model);
        _scorePool.Return(strategy);
    }
}