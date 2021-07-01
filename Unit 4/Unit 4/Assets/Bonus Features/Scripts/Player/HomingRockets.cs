using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingRockets : MonoBehaviour
{
    private Transform target;
    private float speed;
    private bool homing;

    private float rocketStrength;
    private float aliveTime;

    private void Update()
    {
        if (homing && target != null)
        {
            Vector3 moveDirection = (target.transform.position - transform.position).normalized;
            transform.position += moveDirection * speed * Time.deltaTime;
            transform.LookAt(target);
        }
    }

    public void Fire(Transform newTarget)
    {
        target = newTarget;
        homing = true;
        Destroy(gameObject, aliveTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(target!=null)
        {
            if(collision.gameObject.CompareTag(target.tag))
            {
                Rigidbody targetRigidbody = collision.gameObject.GetComponent<Rigidbody>();
                Vector3 away = -collision.contacts[0].normal;
                targetRigidbody.AddForce(away * rocketStrength, ForceMode.Impulse);
            }
        }
    }

}
