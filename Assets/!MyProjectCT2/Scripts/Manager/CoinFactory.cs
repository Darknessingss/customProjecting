using UnityEngine;

public static class CoinFactory
{
    public static Coin Create(GameObject prefab, Vector3 position, Transform parent = null)
    {
        GameObject instance = Object.Instantiate(prefab, position, Quaternion.identity, parent);

        return instance.GetComponent<Coin>();
    }
}