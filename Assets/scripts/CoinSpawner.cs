using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public Transform carTransform;
    public float distanceThreshold = 40f;
    public float spawnOffset = 23f;
    public float minZ = -6f;
    public float maxZ = 6f;
    public GameObject player; // GameObject représentant le joueur
    public GameObject enemy; // GameObject représentant l'ennemi


    private float lastSpawnPosition;

    void Start()
    {
        lastSpawnPosition = carTransform.position.x;
    }

    void Update()
    {
        if (carTransform.position.x - lastSpawnPosition >= distanceThreshold)
        {
            SpawnCoin();
            lastSpawnPosition = carTransform.position.x;
        }
    }

    void SpawnCoin()
    {
        Vector3 spawnPosition = new Vector3(carTransform.position.x + spawnOffset, 0f, Random.Range(minZ, maxZ));
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }

    
}
