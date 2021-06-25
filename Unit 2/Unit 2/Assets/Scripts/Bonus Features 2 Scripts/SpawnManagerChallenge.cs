using UnityEngine;

public class SpawnManagerChallenge : MonoBehaviour
{
    public GameObject[] animalPrefab;

    [SerializeField] private float spawnRangeX = 20;
    [SerializeField] private float spawnPoxZ = 20;
    [SerializeField] private float spawnPoxMinZ = 7;
    [SerializeField] private float spawnPoxMaxZ = 19;
    [SerializeField] private float spawnDelay = 2f;
    [SerializeField] private float spawnInterval = 1.5f;

    private void Start()
    {
        // Calling the SpawnRandomAnimals method after 2 seconds, and every 1.5 second
        InvokeRepeating(nameof(SpawnRandomAnimals), spawnDelay, spawnInterval);
        InvokeRepeating(nameof(SpawnAnimalsLeft), spawnDelay, spawnInterval);
        InvokeRepeating(nameof(SpawnAnimalsRight), spawnDelay, spawnInterval);
    }

    //Randomly generate animal index and spawn position
    private void SpawnRandomAnimals()
    {
        int animalIndex = Random.Range(0, animalPrefab.Length);
        Vector3 animalSpawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0, spawnPoxZ);

        if (animalIndex > animalPrefab.Length - 1)
        {
            return;
        }
        Instantiate(animalPrefab[animalIndex], animalSpawnPos, animalPrefab[animalIndex].transform.rotation);
    }
    private void SpawnAnimalsLeft()
    {
        int animalIndex = Random.Range(0, animalPrefab.Length);
        Vector3 animalSpawnPos = new Vector3(-spawnRangeX, 0, Random.Range(spawnPoxMinZ, spawnPoxMaxZ));
        Vector3 rotation = new Vector3(0, 90, 0);

        if (animalIndex > animalPrefab.Length - 1)
        {
            return;
        }
        Instantiate(animalPrefab[animalIndex], animalSpawnPos, Quaternion.Euler(rotation));
    }
    private void SpawnAnimalsRight()
    {
        int animalIndex = Random.Range(0, animalPrefab.Length);
        Vector3 animalSpawnPos = new Vector3(spawnRangeX, 0, Random.Range(spawnPoxMinZ, spawnPoxMaxZ));
        Vector3 rotation = new Vector3(0, -90, 0);

        if (animalIndex > animalPrefab.Length - 1)
        {
            return;
        }
        Instantiate(animalPrefab[animalIndex], animalSpawnPos, Quaternion.Euler(rotation));
    }
}