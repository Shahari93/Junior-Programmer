using System.Collections;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{

    private Rigidbody playerRB;
    private bool jump = false;

    void Start()
    {
        playerRB = GetComponentInChildren<Rigidbody>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }

    private void FixedUpdate()
    {
        if(jump)
        {
            playerRB.AddForce(Vector3.up * 10, ForceMode.Impulse);
            jump = false;
        }
    }
}
