using UnityEngine;

public class BoxSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public GameObject boxPrefab;
    public Transform carTransform;
    public float distanceThreshold = 40f;
    public float spawnOffset = 23f;
    public float minZ = -6f;
    public float maxZ = 6f;

    private float lastSpawnPosition;

    void Start()
    {
        lastSpawnPosition = carTransform.position.x;
    }

    void Update()
    {
        if (carTransform.position.x - lastSpawnPosition >= distanceThreshold)
        {
            SpawnObject();
            lastSpawnPosition = carTransform.position.x;
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPositionCoin = new Vector3(carTransform.position.x + spawnOffset, 0f, Random.Range(minZ, maxZ));
        GameObject coin = Instantiate(coinPrefab, spawnPositionCoin, Quaternion.identity);

        Vector3 spawnPositionBox;
        do
        {
            spawnPositionBox = new Vector3(carTransform.position.x + spawnOffset, 0.41f, Random.Range(minZ, maxZ));
        } while (Vector3.Distance(spawnPositionBox, spawnPositionCoin) < 2f); // Adjust this threshold as needed

        Instantiate(boxPrefab, spawnPositionBox, Quaternion.identity);
    }
}

