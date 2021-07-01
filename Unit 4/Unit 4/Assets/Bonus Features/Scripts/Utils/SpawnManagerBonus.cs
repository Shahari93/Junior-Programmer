using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerBonus : MonoBehaviour
{
    [SerializeField] private GameObject[] enemyPrefab;
    [SerializeField] private GameObject[] powerupPrefab;
    [SerializeField] private float spawnRange = 9.0f;
    public int enemiesInScene;
    private int waveNumber = 1;

    void Start()
    {
        SpawnEnemyWave(waveNumber);
        SpawnPowerup();
    }

    private void Update()
    {
        // Adding all the enemies instances to the array of enemies in scene
        enemiesInScene = FindObjectsOfType<EnemyBonus>().Length;

        // Checking if there are no enemies in scene
        if (enemiesInScene == 0)
        {
            // Increasing the number of enemies in the new wave
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            SpawnPowerup();
            if (waveNumber % 3 == 0)
            {
                SpawnBoss();
            }
        }

        Debug.Log(waveNumber);
    }

    private void SpawnEnemyWave(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            int index = Random.Range(0, enemyPrefab.Length);
            GameObject enemy = Instantiate(enemyPrefab[index], GenerateRandomPos(), enemyPrefab[index].transform.rotation) as GameObject;
            enemy.GetComponent<EnemyBonus>().EnemyType(enemy);
        }
    }

    private void SpawnPowerup()
    {
        int index = Random.Range(0, powerupPrefab.Length);
        Instantiate(powerupPrefab[index], GenerateRandomPos(), powerupPrefab[index].transform.rotation);
    }

    // We use a return type whenever we need to get back a calculation that we did
    private Vector3 GenerateRandomPos()
    {
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);

        Vector3 randomPos = new Vector3(spawnPosX, 0.15f, spawnPosZ);

        return randomPos;
    }

    private void SpawnBoss()
    {
        Instantiate(enemyPrefab[3], GenerateRandomPos(), enemyPrefab[3].transform.rotation);
    }
}
