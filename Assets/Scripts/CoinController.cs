using UnityEngine;

public class CoinController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;

    // Update is called once per frame
    private void Update()
    {
        transform.Translate(-Vector3.forward * movementSpeed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        ScoreManager.Instance.AddScore();
        Destroy(gameObject);
    }
}