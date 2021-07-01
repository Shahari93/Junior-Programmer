using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float forwardMovement;
    private float powerupStrength = 15f;
    private bool isPlayerMoving;
    private bool hasPowerup = false;

    private Rigidbody playerRB;
    private GameObject focalPoint;
    public GameObject powerupIndicator;

    WaitForSeconds powerupCountdown = new WaitForSeconds(7);

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        forwardMovement = Input.GetAxis("Vertical");
        if (forwardMovement > 0.1f || forwardMovement < -0.1f)
        {
            isPlayerMoving = true;
        }
        else
        {
            isPlayerMoving = false;
        }

        powerupIndicator.transform.position = transform.position + new Vector3(0, -0.55f, 0);
    }

    private void FixedUpdate()
    {
        if (isPlayerMoving)
        {
            // We take the local forward direction of the focal point so the ball will move in that forward direction
            playerRB.AddForce(focalPoint.transform.forward * speed * forwardMovement);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Powerup"))
        {
            hasPowerup = true;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdown());
        }
    }


    IEnumerator PowerupCountdown()
    {
        yield return powerupCountdown;
        hasPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
        {
            EnemyKnockback(collision);
        }
    }

    private void EnemyKnockback(Collision collision)
    {
        Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>(); // getting the enemy rb
        Vector3 awayFromPlayer = (collision.gameObject.transform.position - this.transform.position); // calculation the direcation that the enemy came from

        enemyRB.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse); // adding force to the enmy in the other direction
    }
}
