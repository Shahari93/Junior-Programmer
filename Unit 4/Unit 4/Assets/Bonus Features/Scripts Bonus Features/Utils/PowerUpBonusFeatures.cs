using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupType { knockback, rocket, jump, none}
public class PowerUpBonusFeatures : MonoBehaviour
{
    public PowerupType powerupType;


    void Update()
    {
        float sinValue = Mathf.Sin(Time.time * 3.0f);
        float yPos = Mathf.Lerp(0.1f, 0.5f, Mathf.Abs(sinValue));
        transform.position = new Vector3(transform.position.x, yPos, transform.position.z);
        transform.Rotate(new Vector3(0.0f, 1.0f, 0.0f), 0.5f, Space.Self);
    }
}
