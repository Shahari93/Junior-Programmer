using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed;
    private float forwardMovement;
    private Rigidbody playerRB;
    private bool isPlayerMoving;
    private GameObject focalPoint;

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
    }

    private void FixedUpdate()
    {
        if (isPlayerMoving)
        {
            // We take the local forward direction of the focal point so the ball will move in that forward direction
            playerRB.AddForce(focalPoint.transform.forward * speed * forwardMovement * Time.deltaTime);
        }
    }
}
