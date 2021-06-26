using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Camera mainCamera;
    private Vector3 offset = new Vector3(11,11,11);
    public GameObject cube;

    private void Start()
    {
        mainCamera = Camera.main;
    }

    private void LateUpdate()
    {
        mainCamera.transform.position = cube.transform.position + offset;
    }
}
