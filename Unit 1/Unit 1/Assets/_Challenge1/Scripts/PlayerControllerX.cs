using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        //transform.Translate(Vector3.back * speed);
        transform.Translate(Vector3.forward * speed * Time.deltaTime ); // fix for challenge 1 and 2 
        transform.GetChild(0).Rotate(-Vector3.forward * speed);

        // tilt the plane up/down based on up/down arrow keys
        transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime * verticalInput); // fix for challenge 3
    }
}
