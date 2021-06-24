using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animalPrefab;
    [SerializeField]
    private float spawnRangeX = 20;
    private float spawnPoxZ = 20;
    private float spawnDelay = 2f;
    private float spawnInterval = 1.5f;

    private void Start()
    {
        // Calling the SpawnRandomAnimals method after 2 seconds, and every 1.5 second
        InvokeRepeating("SpawnRandomAnimals", spawnDelay, spawnInterval);
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
}
