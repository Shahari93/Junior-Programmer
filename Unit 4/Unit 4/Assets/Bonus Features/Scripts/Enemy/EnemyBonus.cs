using UnityEngine;

public class EnemyBonus : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private Rigidbody enemyRB;
    private GameObject playerGO;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        playerGO = GameObject.Find("Player");
    }

    private void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CalcDistance();
    }

    // We're normalizing the vector to make sure that the speed of the enemy remains the same no matter the distance
    private void CalcDistance()
    {
        Vector3 distance = (playerGO.transform.position - this.transform.position).normalized;
        enemyRB.AddForce(distance * speed);
    }

    public void EnemyType(GameObject enemy)
    {
        if (enemy.gameObject.name == "Enemy 2" + "(Clone)")
        {
            speed = 7.5f;
        }
        else if (enemy.gameObject.name == "Enemy 3" + "(Clone)")
        {
            speed = 9f;
        }
    }
}
