using UnityEngine;

public class Coin : MonoBehaviour
{
    [Header("Вращение")]
    [SerializeField] private Vector3 rotationSpeed = new Vector3(0, 180, 0);


    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player") && !other.CompareTag("Magnet"))
            return;

        WalletManager.Instance.Add(1 + Inventory.Instance.CoinValueLevel);
        Destroy(gameObject);
    }
}