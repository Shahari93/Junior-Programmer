using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayerSplitScreen : MonoBehaviour
{
    public GameObject player;
    [SerializeField] private Vector3 offset;
    //Late update accours after the main update runs
    void LateUpdate()
    {
        transform.transform.position = player.transform.position + offset;
    }
}