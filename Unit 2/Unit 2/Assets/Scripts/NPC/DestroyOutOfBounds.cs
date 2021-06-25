using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBoundry = 30f;
    private float lowerBound = -10f;

    void Update()
    {
        DestroyIfOutOfBounds();
    }

    // Destroy the game object if it passes a z position
    private void DestroyIfOutOfBounds()
    {
        if (transform.position.z > topBoundry)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Debug.Log("Game Over!");
            Destroy(gameObject);
        }
    }
}
