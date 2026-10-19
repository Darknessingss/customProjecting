using UnityEngine;

public class SpawnCoin : MonoBehaviour
{
    [SerializeField] private GameObject CoinPrefab;
    [SerializeField] private BoxCollider spawnArea;

    [SerializeField] private int count = 10;

    void Start()
    {

        for (int i = 0; i < count; i++)
            SpawnPrefabs();
    }

    private void SpawnPrefabs()
    {
        Bounds b = spawnArea.bounds;

        Vector3 pos = new Vector3(
            Random.Range(b.min.x, b.max.x),
            Random.Range(b.min.y, b.max.y),
            Random.Range(b.min.z, b.max.z)
        );

        Instantiate(CoinPrefab, pos, Quaternion.identity);
    }
}
