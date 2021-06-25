using UnityEngine;

public class PlayerControllerChallenge : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    public float speed;
    [SerializeField] private float xRange = 10;
    [SerializeField] private float zRangeMinimum = -1.1f;
    [SerializeField] private float zRangeMaximum = -1.1f;
    [SerializeField] GameObject foodProjectilePrefab;

    public int playerLives = 3;
    public int playerScore = 0;

    private void Start()
    {
        Debug.Log("Lives: " + playerLives);
        Debug.Log("Score: " + playerScore);
    }

    // Update is called once per frame
    void Update()
    {
        ReadInput();
        LimitPos();
    }

    private void ReadInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        // Creating a vector 3 with the axis
        Vector3 movement = new Vector3(horizontalInput, 0, verticalInput);
        transform.Translate(movement.normalized * Time.deltaTime * speed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            // launch projectile from the player
            GameObject projectile = Instantiate(foodProjectilePrefab, this.transform.position, foodProjectilePrefab.transform.rotation) as GameObject;
        }
    }

    // Limiting the player movement 
    private void LimitPos()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.z < zRangeMinimum)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMinimum);
        }
        if (transform.position.z > zRangeMaximum)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRangeMaximum);
        }
    }
}
