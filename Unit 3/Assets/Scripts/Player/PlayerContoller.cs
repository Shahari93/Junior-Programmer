using System.Collections;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    public bool isGameOver;
    [Header("Particles")]
    public ParticleSystem explosionParticles;
    public ParticleSystem dirtParticles;

    [Header("Audio")]
    public AudioClip[] sfx = new AudioClip[2];
    public AudioSource playerAudio;

    private Rigidbody playerRB;
    private Animator playerAnim;

    [Header("Jump variables")]
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float gravityModifer; // control how fast the player will fall to the ground
    private bool jump = false;
    private bool isOnGround = true;

    void Start()
    {
        // Getting the player components
        playerAudio = GetComponent<AudioSource>();
        playerRB = GetComponent<Rigidbody>();
        playerAnim = GetComponent<Animator>();
        Physics.gravity *= gravityModifer;
    }

    private void Update()
    {
        // Checking if the player pressed on space and is on the ground. if both true then we jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !isGameOver)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        // The jump mechanics
        if (jump)
        {
            PlayerJump();
        }
    }

    private void PlayerJump()
    {
        playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        playerAnim.SetTrigger("Jump_trig"); // The Trigger type is appropriate for representing an action that will occur for a short period
        jump = false;
        isOnGround = false;
        dirtParticles.Stop();
        playerAudio.PlayOneShot(sfx[1], 0.9f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
            dirtParticles.Play();
        }

        else if (collision.gameObject.CompareTag("Obstacles"))
        {
            ObstaclesCollision();
        }
    }

    private void ObstaclesCollision()
    {
        isGameOver = true;
        playerAnim.SetBool("Death_b", true);
        playerAnim.SetInteger("DeathType_int", 1);
        explosionParticles.Play();
        dirtParticles.Stop();
        playerAudio.PlayOneShot(sfx[0], 0.9f);
    }
}