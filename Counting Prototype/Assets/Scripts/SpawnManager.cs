using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject ballPrefab;
    private float xPos = 3.41f;
    private float startDelay = 1.5f, invokeTime = 1f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnBalls), startDelay, invokeTime);
    }

    private void SpawnBalls()
    {
        GameObject ball = Instantiate(ballPrefab, RandomPos(), ballPrefab.transform.rotation);
    }

    private Vector3 RandomPos()
    {
        return new Vector3(Random.Range(-xPos, xPos), 5.91f, -0.201f);
    }
}