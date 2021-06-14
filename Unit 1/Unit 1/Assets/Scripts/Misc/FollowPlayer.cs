using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{

    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);

    // Start is called before the first frame update
    void Start()
    {

    }


    // In Update method both the camera and the car moves at the same time
    /*void Update()
    {
        //offset the camera behind the player by adding to the players position
        //transform.position = player.transform.position + new Vector3(0, 5, -7);
        transform.position = player.transform.position + offset;
    }*/

    //Late update accours after the main update runs
    void LateUpdate()
    {
        //offset the camera behind the player by adding to the players position
        //transform.position = player.transform.position + new Vector3(0, 5, -7);
        transform.position = player.transform.position + offset;
    }
}
