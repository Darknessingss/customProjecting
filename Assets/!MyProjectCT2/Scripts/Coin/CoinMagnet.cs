using UnityEngine;

[RequireComponent(typeof(SphereCollider))]
public class CoinMagnet : MonoBehaviour
{
    [SerializeField] private float baseRadius = 1.5f;
    [SerializeField] private float radiusPerLevel = 1.5f;

    [SerializeField] private SphereCollider _collider;

    private void Awake()
    {
        _collider.isTrigger = true;
    }

    private void Start()
    {
        Inventory.Instance.OnChanged += ApplyRadius;
        ApplyRadius();
    }

    private void OnDestroy()
    {
        if (Inventory.Instance != null)
            Inventory.Instance.OnChanged -= ApplyRadius;
    }

    private void ApplyRadius()
    {
        int level = Inventory.Instance.MagnetLevel;

        _collider.enabled = level > 0;
        if (!_collider.enabled) 
            return;

        _collider.radius = baseRadius + (level - 1) * radiusPerLevel;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!_collider.enabled) 
            return;
        if (!other.TryGetComponent(out Coin coin)) 
            return;
    }
}