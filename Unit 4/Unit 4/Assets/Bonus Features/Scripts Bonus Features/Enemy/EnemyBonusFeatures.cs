using UnityEngine;
[System.Serializable]
public enum EnemyType { normal, fast, faster, boss }
public class EnemyBonusFeatures : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody enemyRB;
    private GameObject playerGO;

    [SerializeField] EnemyType enemyType = EnemyType.normal;

    // Start is called before the first frame update
    void Start()
    {
        enemyRB = GetComponent<Rigidbody>();
        playerGO = GameObject.Find("Player");

        switch (enemyType)
        {
            case EnemyType.normal:
                speed = 5f;
                break;
            case EnemyType.fast:
                speed = 7.5f;
                break;
            case EnemyType.faster:
                speed = 9f;
                break;
            case EnemyType.boss:
                speed = 11f;
                transform.localScale = new Vector3(2.5f, 2.5f, 2.5f);
                break;
        }
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
}
