using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnRange = 9.0f;
    public int enemiesInScene;
    private int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
    }

    private void Update()
    {
        // Adding all the enemies instances to the array of enemies in scene
        enemiesInScene = FindObjectsOfType<Enemy>().Length;
        // Checking if there are no enemies in scene
        if (enemiesInScene == 0)
        {
            // Increasing the number of enemies in the new wave
            waveNumber++;
            SpawnEnemyWave(waveNumber);
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateRandomPos(), enemyPrefab.transform.rotation);
        }
    }

    // We use a return type whenever we need to get back a calculation that we did
    private Vector3 GenerateRandomPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0.15f, spawnPosZ);

        return randomPos;
    }
}
