using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetShare : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManagerShare gameManager;
    private MouseSwipe mouseSwipe;
    [SerializeField] ParticleSystem explosionParticles;

    [SerializeField] private int scoreValue;


    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerShare>();
        mouseSwipe = GameObject.Find("Main Camera").GetComponent<MouseSwipe>();

        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(new Vector3(RandomTorque(), RandomTorque(), RandomTorque())); // Adding a spin to the object

        transform.position = RandomPos();
    }


    

    // Called when we entered a collider and pressed down on the mouse key
    private void OnMouseEnter()
    {
        // Only beign able to destroy objects, if the game is active
        if (gameManager.isGameActive && !gameManager.isGamePaused && mouseSwipe.isMouseClicked)
        {
            Destroy(gameObject);
            Instantiate(explosionParticles, transform.position, explosionParticles.transform.rotation);
            gameManager.UpdateScore(scoreValue);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.UpdateLives(1);
            if (gameManager.lives <= 0)
            {
                gameManager.GameOver();
                gameManager.lives = 0;
            }
        }
    }

    // Generate random force, and return the new vector
    Vector3 RandomForce()
    {
        float minSpeed = 12f;
        float maxSpeed = 16f;
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Generate random pos, and return the new vector
    Vector3 RandomPos()
    {
        float xRangePos = 4;
        float yPos = Random.Range(-3.5f, -2f);
        return new Vector3(Random.Range(-xRangePos, xRangePos), yPos);
    }

    // Generate random torque, and return the new range
    float RandomTorque()
    {
        float torqueForce = 10;
        return Random.Range(-torqueForce, torqueForce);
    }
}
