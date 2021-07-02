using System.Collections;
using UnityEngine;

public class HomingRockets : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] GameObject spawnPos;
    private Transform target;
    private PlayerControllerBonusFeatures playerController;


    private void Start()
    {
        playerController = FindObjectOfType<PlayerControllerBonusFeatures>();
    }


    private void Update()
    {
        if (FindObjectOfType<EnemyBonusFeatures>() != null)
        {
            target = FindObjectOfType<EnemyBonusFeatures>().transform;
            Vector3 moveDir = (target.transform.position - this.transform.position).normalized;
            this.transform.position += moveDir * speed * Time.deltaTime;
            this.transform.LookAt(target);
        }
        Destroy(gameObject, 5f);
    }

    public void FireRocket()
    {
        {
            GameObject rocket = Instantiate(this.gameObject, spawnPos.transform.position, this.gameObject.transform.rotation);
            rocket.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerController.EnemyKnockback(collision);
        }
    }
}
