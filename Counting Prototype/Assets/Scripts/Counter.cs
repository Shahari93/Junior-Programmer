using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Counter : MonoBehaviour
{
    [SerializeField] int boxValue;
    public TextMeshProUGUI counterText;
    private static int count = 0;

    private void Start()
    {
        count = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
            count += boxValue;
            counterText.text = "Points : " + count;
    }
}
