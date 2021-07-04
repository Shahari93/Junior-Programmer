using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody targetRb;

    void Start()
    {
        targetRb = GetComponent<Rigidbody>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(new Vector3(RandomTorque(), RandomTorque(), RandomTorque())); // Adding a spin to the object

        transform.position = RandomPos();
    }

    // Called when we entered a collider and pressed down on the mouse key
    private void OnMouseDown()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }

    // Generate random force
    Vector3 RandomForce()
    {
        float minSpeed = 12f;
        float maxSpeed = 16f;
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Generate random pos
    Vector3 RandomPos()
    {
        float xRangePos = 4;
        float yPos = Random.Range(-3.5f, -2f);
        return new Vector3(Random.Range(-xRangePos,xRangePos), yPos);
    }

    // Generate random torque
    float RandomTorque()
    {
        float torqueForce = 10;
        return Random.Range(-torqueForce, torqueForce);
    }
}
