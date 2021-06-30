using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerBonus : MonoBehaviour
{
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    [SerializeField] private GameObject[] obstaclePrefab;
    [SerializeField] private float startDelay = 2f;
    [SerializeField] private float spawnRate;
    private PlayerContollerBonus playerContoller;

    // Start is called before the first frame update
    void Start()
    {
        spawnRate = Random.Range(2f, 2.5f);
        if (!playerContoller.isGameOver)
        {

            playerContoller = GameObject.Find("PlayerCharacter").GetComponent<PlayerContollerBonus>();
        }
        InvokeRepeating(nameof(SpawnObstacle), startDelay, spawnRate);
    }

    private void Update()
    {
        // Canceling invoke if the game is over
        if (playerContoller.isGameOver)
        {
            CancelInvoke(nameof(SpawnObstacle));
        }
    }

    private void SpawnObstacle()
    {
        int randomIndex = Random.Range(0, obstaclePrefab.Length);
        Debug.Log(randomIndex);
        Instantiate(obstaclePrefab[randomIndex], spawnPos, obstaclePrefab[randomIndex].transform.rotation);
    }
}
