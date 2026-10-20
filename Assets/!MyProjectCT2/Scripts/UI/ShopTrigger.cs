using UnityEngine;

public class ShopTrigger : MonoBehaviour
{
    [SerializeField] private GameObject shopPanel;

    private void Start()
    {
        if (shopPanel != null)
            shopPanel.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) 
            return;
        shopPanel.SetActive(true);
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) 
            return;
        shopPanel.SetActive(false);
    }
}