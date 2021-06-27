using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    [SerializeField] private GameObject obstaclePrefab = null;
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(2f, 2.5f);
        InvokeRepeating(nameof(SpawnObstacle), startDelay, spawnRate);
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
    }
}
