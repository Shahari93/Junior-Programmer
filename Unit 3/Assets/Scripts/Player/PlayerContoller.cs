using System.Collections;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    [Header("Component")]
    private Rigidbody playerRB;
    private Animator playerAnim;

    private bool jump = false;
    private bool isOnGround = true;
    public bool isGameOver;
    [Header("Jump variables")]
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float gravityModifer; // control how fast the player will fall to the ground

    void Start()
    {
        // Getting the player components
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
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            playerAnim.SetTrigger("Jump_trig"); // The Trigger type is appropriate for representing an action that will occur for a short period
            jump = false;
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isOnGround = true;
        }

        else if(collision.gameObject.CompareTag("Obstacles"))
        {
            Debug.Log("Game Over!");
            isGameOver = true;
            playerAnim.SetBool("Death_b", true);
            playerAnim.SetInteger("DeathType_int", 1);
        }
    }
}