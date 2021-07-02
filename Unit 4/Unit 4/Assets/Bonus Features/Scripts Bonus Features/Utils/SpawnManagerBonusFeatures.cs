using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerBonusFeatures : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject[] powerupPrefab;
    [SerializeField] private float spawnRange = 9.0f;
    public int enemiesInScene;
    private int waveNumber = 1;
    EnemyType currentEnemyType = EnemyType.normal;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    private void Update()
    {
        // Adding all the enemies instances to the array of enemies in scene
        enemiesInScene = FindObjectsOfType<EnemyBonusFeatures>().Length;

        // Checking if there are no enemies in scene
        if (enemiesInScene == 0)
        {
            // Increasing the number of enemies in the new wave
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
        }
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int randIndex = Random.Range(0, enemyPrefab.Length);
            Instantiate(enemyPrefab[randIndex], GenerateRandomPos(), enemyPrefab[randIndex].transform.rotation);
        }
    }

    private void SpawnPowerup()
    {
        int randIndex = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[randIndex], GenerateRandomPos(), powerupPrefab[randIndex].transform.rotation);
        if(waveNumber % 3 == 0)
        {
            currentEnemyType = EnemyType.boss;
            Instantiate(powerupPrefab[powerupPrefab.Length - 1], GenerateRandomPos(), powerupPrefab[powerupPrefab.Length - 1].transform.rotation);
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
