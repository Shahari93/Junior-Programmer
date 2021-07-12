using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseSwipe : MonoBehaviour
{
    private Camera mainCam;
    private GameManagerShare gameManager;
    public bool isMouseClicked = false;

    [Header("Trail Renderer")]
    public Color trailColor = new Color(0, 0, 1);
    public float distanceFromCamera = 5;
    public float startWidth = 0.2f;
    public float endWidth = 0f;
    public float trailTime = 0.2f;
    Transform trailTransform;

    private void Start()
    {
        mainCam = GameObject.Find("Main Camera").GetComponent<Camera>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerShare>();
        GameObject trailObj = new GameObject("Mouse Trail");
        trailTransform = trailObj.transform;
        TrailRenderer trail = trailObj.AddComponent<TrailRenderer>();
        trail.time = -1f;
        trail.time = trailTime;
        trail.startWidth = startWidth;
        trail.endWidth = endWidth;
        trail.numCapVertices = 2;
        trail.sharedMaterial = new Material(Shader.Find("Unlit/Color"));
        trail.sharedMaterial.color = trailColor;
    }
    private void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButton(0))
            {
                isMouseClicked = true;
                MoveTrailToCursor(Input.mousePosition);
            }
            if (Input.GetMouseButtonUp(0))
            {
                isMouseClicked = false;
            }
        }
    }

    void MoveTrailToCursor(Vector3 screenPosition)
    {
        trailTransform.position = mainCam.ScreenToWorldPoint(new Vector3(screenPosition.x, screenPosition.y, distanceFromCamera));
    }
}
