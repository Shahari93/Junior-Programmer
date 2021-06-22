using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float topBoundry = 30f;
    private float lowerBound = -10f;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBoundry)/* || transform.position.z < lowerBound)*/
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < lowerBound)
        {
            Destroy(gameObject);
        }
    }
}
