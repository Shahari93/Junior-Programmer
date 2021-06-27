using System.Collections;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    private Rigidbody playerRB;
    private bool jump = false;
    private bool isOnGround = true;
    [Header("Jump variables")]
    [SerializeField] private float jumpForce = 10;
    [SerializeField] private float gravityModifer;

    void Start()
    {
        playerRB = GetComponentInChildren<Rigidbody>();
        Physics.gravity *= gravityModifer;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if (jump)
        {
            playerRB.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            jump = false;
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}