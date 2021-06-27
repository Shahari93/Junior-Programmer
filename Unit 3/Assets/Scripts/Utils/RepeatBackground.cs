using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
    private Vector3 startPos;
    private float repeatWidth;

    private void Start()
    {
        // setting the start pos to the position of the background
        startPos = transform.position;

        // getting the halfway point of the collider
        repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    private void Update()
    {
        // Checking to see if the background pos is less than the star pos with offset
        if(transform.position.x < startPos.x - repeatWidth)
        {
            // setting the background pos to the start pos (the first position of the background)
            transform.position = startPos;
        }
    }
}
