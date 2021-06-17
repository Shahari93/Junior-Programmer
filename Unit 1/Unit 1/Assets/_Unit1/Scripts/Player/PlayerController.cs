using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Private variables
    private float speed = 5.0f;
    private float turnSpeed = 25.0f;
    private float horizontalInput;
    private float forwardInput;

    //Serialized variables
    [SerializeField] GameObject rightBreakLights;
    [SerializeField] GameObject leftBreakLights;
    [SerializeField] Light rightBlinker;
    [SerializeField] Light leftBlinker;

    // Start is called before the first frame update
    void Start()
    {
        SetBreakLights(false);
    }

    // Update is called once per frame
    void Update()
    {
        // This is where we get input
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        if (forwardInput <= 0)
        {
            SetBreakLights(true);
        }
        else
        {
            SetBreakLights(false);
        }


        if (horizontalInput > 0 && forwardInput > 0)
        {
            rightBlinker.gameObject.SetActive(false);
            leftBlinker.gameObject.SetActive(true);
            Mathf.PingPong(leftBlinker.intensity, .4f);
        }
        else if (horizontalInput < 0 && forwardInput > 0)
        {
            rightBlinker.gameObject.SetActive(true);
            leftBlinker.gameObject.SetActive(false);
        }
        else
        {
            rightBlinker.gameObject.SetActive(false);
            leftBlinker.gameObject.SetActive(false);
        }

        // Move the vehicle forward
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput); // moves 20 Unity units in one second. Time.deltaTime is the interval in seconds from the last frame to the current one
        // Turn the vehicle
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * horizontalInput); // rotating the object based on it's y axis (vector.up), by time (Time.deltaTime)

        //transform.Translate(0, 0, 1);
        //transform.Translate(Vector3.forward);
        //transform.Translate(Vector3.right * Time.deltaTime * turnSpeed * horizontalInput);
    }

    private void SetBreakLights(bool onOrOff)
    {
        rightBreakLights.SetActive(onOrOff);
        leftBreakLights.SetActive(onOrOff);
    }
}
