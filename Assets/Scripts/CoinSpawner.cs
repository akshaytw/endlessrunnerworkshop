using System.Collections;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private GameObject coin;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnTimeInterval;

    private void Start()
    {
        StartCoroutine(SpawnCoin());
    }

    private IEnumerator SpawnCoin()
    {
        Instantiate(coin, GetRandomSpawnPosition(), spawnPoint.rotation);
        yield return new WaitForSeconds(spawnTimeInterval);
        StartCoroutine(SpawnCoin());
    }

    private Vector3 GetRandomSpawnPosition()
    {
        var randomPoint = Random.Range(0, 3);
        return randomPoint switch
        {
            0 => spawnPoint.position + Vector3.left,
            1 => spawnPoint.position,
            2 => spawnPoint.position + Vector3.right,
            _ => default
        };
    }
}
