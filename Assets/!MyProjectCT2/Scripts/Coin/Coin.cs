using Unity.VisualScripting;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private float _frequency = 1.25f;
    [SerializeField] private float _amplitude = 0.2f;

    [SerializeField] Vector3 rotationSpeed = new Vector3(0, 180, 0);
    private Vector3 startPos;
    private float phase;

        
    private void Start()
    {
        startPos = transform.position;
        phase = Random.Range(0f, Mathf.PI * 2f);
    }

    private void Update()
    {
        {
            float y = Mathf.Sin(Time.time * _frequency + phase) * _amplitude;
            transform.position = startPos + new Vector3(0f, y, 0f);

            transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }


    private void Die()
    {
        Destroy(gameObject);
    }

}
