using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    // Private variables
    private float speed;
    private float rpm;
    private float horizontalInput;
    private float forwardInput;
    [SerializeField] private float horsePower = 0f;
    [SerializeField] private float turnSpeed = 25.0f;


    //Serialized variables
    public string playerID;
    private Rigidbody playerRb;
    [SerializeField] TextMeshProUGUI speedometerText;
    [SerializeField] TextMeshProUGUI rpmText;
    [SerializeField] GameObject centerOfMass;

    [SerializeField] private List<WheelCollider> allWheels;
    [SerializeField] private int howManyWheels;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        playerRb.centerOfMass = centerOfMass.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // This is where we get input
        horizontalInput = Input.GetAxis("Horizontal" + playerID);
        forwardInput = Input.GetAxis("Vertical" + playerID);

        //// Move the vehicle forward
        //transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); // moves 20 Unity units in one second. Time.deltaTime is the interval in seconds from the last frame to the current one
        //                                                                              // Turn the vehicle


        // Adding physics force to the car on the relative axis (local)
        if (IsOnGround())
        {
            playerRb.AddRelativeForce(Vector3.forward * horsePower * forwardInput);

            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput); // rotating the object based on it's y axis (vector.up), by time (Time.deltaTime)
            speed = Mathf.RoundToInt(playerRb.velocity.magnitude * 3.6f); // returns the speed in kph
            speedometerText.SetText("Speed: " + speed + "kph");
            rpm = Mathf.Round(speed % 30) * 40;
            rpmText.SetText("RPM: " + rpm); 
        }
    }

    bool IsOnGround()
    {
        howManyWheels = 0;
        foreach (WheelCollider wheel in allWheels)
        {
            if(wheel.isGrounded)
            howManyWheels++;
        }
        if (howManyWheels >= 2)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
