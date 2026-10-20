using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private BoxCollider spawnArea;
    [SerializeField] private int baseCount = 10;

    private void Start()
    {
        Inventory.Instance.OnChanged += Respawn;
        Respawn();
    }

    private void OnDestroy()
    {
        if (Inventory.Instance != null)
            Inventory.Instance.OnChanged -= Respawn;
    }

    public void Respawn()
    {
        int count = baseCount + Inventory.Instance.SpawnCountLevel;
        for (int i = 0; i < count; i++)
            SpawnOne();
    }

    private void SpawnOne()
    {
        Bounds b = spawnArea.bounds;
        Vector3 pos = new Vector3(
            Random.Range(b.min.x, b.max.x),
            Random.Range(b.min.y, b.max.y),
            Random.Range(b.min.z, b.max.z)
        );
        CoinFactory.Create(coinPrefab, pos);
    }
}