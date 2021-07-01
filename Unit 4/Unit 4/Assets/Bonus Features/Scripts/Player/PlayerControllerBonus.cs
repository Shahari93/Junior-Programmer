using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBonus : MonoBehaviour
{
    [SerializeField] private float speed;
    private float forwardMovement;
    private float powerupStrength = 15f;
    private bool isPlayerMoving;
    private bool hasPowerup;

    private Rigidbody playerRB;
    private GameObject focalPoint;
    public GameObject powerupIndicator;

    WaitForSeconds powerupCountdown = new WaitForSeconds(7);

    public PowerUpType currentPowerup = PowerUpType.None;
    public GameObject rocketPrefab;
    private GameObject tmpRocket;
    private Coroutine powerUpCorutine;

    public float hangTime;
    public float smashSpeed;
    public float explosionForce;
    public float explosionRadius;
    bool smashing = false;
    float floorY;

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

        if (currentPowerup == PowerUpType.Rockets && Input.GetKeyDown(KeyCode.F))
        {
            LaunchRockets();
        }
        if (currentPowerup == PowerUpType.Smash && Input.GetKeyDown(KeyCode.Space) &&
!smashing)
        {
            smashing = true;
            StartCoroutine(Smash());
        }

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
            currentPowerup = other.gameObject.GetComponent<PowerUpBonus>().powerUpType;
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);

            if (powerupCountdown != null)
            {
                StopCoroutine(PowerupCountdown());
            }

            powerUpCorutine = StartCoroutine(PowerupCountdown());
        }
    }


    IEnumerator PowerupCountdown()
    {
        yield return powerupCountdown;
        hasPowerup = false;
        currentPowerup = PowerUpType.None;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && currentPowerup == PowerUpType.Pushback)
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

    private void LaunchRockets()
    {
        foreach (var enemy in FindObjectsOfType<EnemyBonus>())
        {
            tmpRocket = Instantiate(rocketPrefab, transform.position + Vector3.up, Quaternion.identity);
            tmpRocket.GetComponent<HomingRockets>().Fire(enemy.transform);
        }
    }

    IEnumerator Smash()
    {
        var enemies = FindObjectsOfType<Enemy>();
        //Store the y position before taking off
        floorY = transform.position.y;
        //Calculate the amount of time we will go up
        float jumpTime = Time.time + hangTime;
        while (Time.time < jumpTime)
        {
            //move the player up while still keeping their x velocity.
            playerRB.velocity = new Vector2(playerRB.velocity.x, smashSpeed);
            yield return null;
        }
        //Now move the player down
        while (transform.position.y > floorY)
        {
            playerRB.velocity = new Vector2(playerRB.velocity.x, -smashSpeed * 2);
            yield return null;
        }
        //Cycle through all enemies.
        for (int i = 0; i < enemies.Length; i++)
        {
            //Apply an explosion force that originates from our position.
            if (enemies[i] != null)
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(explosionForce,
                transform.position, explosionRadius, 0.0f, ForceMode.Impulse);
        }
        //We are no longer smashing, so set the boolean to false
        smashing = false;
    }

}
