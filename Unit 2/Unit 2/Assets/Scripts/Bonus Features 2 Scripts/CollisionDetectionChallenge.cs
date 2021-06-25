using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetectionChallenge : MonoBehaviour
{
    int playerLives = 3;
    private void Start()
    {
        Debug.Log(playerLives);
    }

    // Whenever there is a collision between the food and animal we destroy both of them
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Animal"))
        {
            playerLives--;
            if (playerLives < 1)
            {
                Destroy(other.gameObject);
                Debug.Log("Game Over!");
            }
            Debug.Log(playerLives);
        }
        Destroy(other.gameObject);
    }
}