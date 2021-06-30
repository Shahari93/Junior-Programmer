using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeftBonus : MonoBehaviour
{
    [SerializeField] private float speed = 15f;
    private float leftBound = -15f;
    private PlayerContollerBonus playerContollerScript;

    private void Start()
    {
        // Assigning the player controller script from the player character to the variable
        playerContollerScript = GameObject.Find("PlayerCharacter").GetComponent<PlayerContollerBonus>();
    }

    private void Update()
    {
        // Moving the background and obstcales to the left only if the game over bool is true
        if (!playerContollerScript.isGameOver)
        {
            if (playerContollerScript.isDash)
            {
                transform.Translate(Vector3.left * Time.deltaTime * (speed * 2));
            }
            else
            {
                transform.Translate(Vector3.left * Time.deltaTime * speed);
            }

        }
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacles"))
        {
            Destroy(gameObject);
        }
    }
}
