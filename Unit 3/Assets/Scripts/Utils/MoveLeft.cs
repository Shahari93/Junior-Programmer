using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    private float leftBound = -15f;
    private PlayerContoller playerContollerScript;

    private void Start()
    {
        // Assigning the player controller script from the player character to the variable
        playerContollerScript = GameObject.Find("PlayerCharacter").GetComponent<PlayerContoller>();
    }

    private void Update()
    {
        // Moving the background and obstcales to the left only if the game over bool is true
        if (!playerContollerScript.isGameOver)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }
    }
}
