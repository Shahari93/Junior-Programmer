using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveFoodForward : MonoBehaviour
{
    public float speed = 40.0f;

    // Moving the gameobject on the z axis based on seconds
    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
