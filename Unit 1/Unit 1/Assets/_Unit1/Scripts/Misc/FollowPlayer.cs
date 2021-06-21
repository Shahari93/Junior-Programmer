using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public GameObject player;
    private Vector3 offset = new Vector3(0, 5, -7);
    private Vector3 driverSeatOffset = new Vector3(0, 5, -7.35f);
    private Camera mainCamera;
    private bool isDriverSeatPerspective;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        SetCameraBool();
    }



    //Late update accours after the main update runs
    void LateUpdate()
    {

        if (!isDriverSeatPerspective)
        {
            mainCamera.transform.position = player.transform.position + offset;
            ChangeCameraPerspective(60, new Vector3(18.74f, -0.385f, 0.039f));
        }

        else
        {
            mainCamera.transform.position = player.transform.position + driverSeatOffset;
            ChangeCameraPerspective(20, new Vector3(7.8f, player.transform.rotation.y, 0.039f));
        }
    }

    private void ChangeCameraPerspective(float fov, Vector3 newEulerAngles)
    {
        mainCamera.fieldOfView = fov;
        mainCamera.transform.eulerAngles = newEulerAngles;
    }

    private void SetCameraBool()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            isDriverSeatPerspective = !isDriverSeatPerspective;
        }
    }
}

#region notNeeded
// In Update method both the camera and the car moves at the same time
/*void Update()
{
    //offset the camera behind the player by adding to the players position
    //transform.position = player.transform.position + new Vector3(0, 5, -7);
    transform.position = player.transform.position + offset;
}*/

//void LateUpdate()
//{
//    offset the camera behind the player by adding to the players position
//    transform.position = player.transform.position + new Vector3(0, 5, -7);
//}
#endregion