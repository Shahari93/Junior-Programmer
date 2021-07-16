using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] float destroyTime;
    private void Start()
    {
        Destroy(gameObject, destroyTime);
    }
}
