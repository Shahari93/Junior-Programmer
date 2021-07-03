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
        float yPos = 5;
        return new Vector3(Random.Range(-xRangePos,xRangePos), -yPos);
    }

    // Generate random torque
    float RandomTorque()
    {
        float torqueForce = 10;
        return Random.Range(-torqueForce, torqueForce);
    }
}
