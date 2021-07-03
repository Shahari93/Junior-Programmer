using System.Collections;
using UnityEngine;

public class PlayerControllerBonusFeatures : MonoBehaviour
{
    [SerializeField] private int jumpForce = 100;
    [SerializeField] private float speed;
    [SerializeField] private float radius;
    private int howManyJumps = 0;
    private float forwardMovement;
    private float powerupStrength = 15f;
    private bool isPlayerMoving;
    private bool hasPowerup = false;
    private bool hasRocketPowerup = false;
    private bool hasJumpPowerup = false;

    [SerializeField] private HomingRockets rockets;
    private Rigidbody playerRB;
    private GameObject focalPoint;
    public GameObject powerupIndicator;
    public GameObject rocketPowerup;
    public GameObject spawnPos;

    WaitForSeconds powerupCountdown = new WaitForSeconds(7);

    PowerupType currentPowerup = PowerupType.none;

    private void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
    }

    private void Update()
    {
        spawnPos.transform.rotation = Quaternion.Euler(gameObject.transform.rotation.x * -1.0f, gameObject.transform.rotation.y * -1.0f, gameObject.transform.rotation.z * -1.0f);
        if (Input.GetKeyDown(KeyCode.Z) && hasRocketPowerup && currentPowerup == PowerupType.rocket)
        {
            rockets.FireRocket();
        }

        if (Input.GetKeyDown(KeyCode.Space) && hasJumpPowerup && currentPowerup == PowerupType.jump && howManyJumps < 1)
        {
            playerRB.AddForceAtPosition(Vector3.up * jumpForce, gameObject.transform.position, ForceMode.Impulse);
            howManyJumps++;
        }
        if (Input.GetKeyDown(KeyCode.X) && hasJumpPowerup)
        {
            playerRB.AddForceAtPosition(Vector3.down * jumpForce * 10, gameObject.transform.position, ForceMode.Impulse);
        }

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
        if (other.CompareTag("Powerup") || other.CompareTag("RocketPowerup") || other.CompareTag("Smash"))
        {
            powerupIndicator.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdown());

            if (other.CompareTag("RocketPowerup"))
            {
                currentPowerup = PowerupType.rocket;
                hasRocketPowerup = true;
            }
            else if (other.CompareTag("Powerup"))
            {
                currentPowerup = PowerupType.knockback;
                hasPowerup = true;
            }
            else if (other.CompareTag("Smash"))
            {
                currentPowerup = PowerupType.jump;
                hasJumpPowerup = true;
            }
        }
    }

    IEnumerator PowerupCountdown()
    {
        yield return powerupCountdown;
        hasPowerup = false;
        hasRocketPowerup = false;
        hasJumpPowerup = false;
        powerupIndicator.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && hasPowerup && currentPowerup == PowerupType.knockback)
        {
            EnemyKnockback(collision);
        }
        if (collision.gameObject.CompareTag("Ground") && howManyJumps > 0)
        {
            var enemies = FindObjectsOfType<EnemyBonusFeatures>();
            for (int i = 0; i < enemies.Length; i++)
            {
                enemies[i].GetComponent<Rigidbody>().AddExplosionForce(powerupStrength, this.transform.position, radius, 0.0f, ForceMode.Impulse); // adding force to the enmy in the other direction
            }
            howManyJumps = 0;
        }
    }

    public void EnemyKnockback(Collision collision)
    {
        Rigidbody enemyRB = collision.gameObject.GetComponent<Rigidbody>(); // getting the enemy rb
        Vector3 awayFromPlayer = (collision.gameObject.transform.position - this.transform.position); // calculation the direcation that the enemy came from

        enemyRB.AddForce(awayFromPlayer * powerupStrength, ForceMode.Impulse); // adding force to the enmy in the other direction
    }
}