using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
    public PlayerControllerChallenge playerController;

    private void Start()
    {
        playerController = FindObjectOfType<PlayerControllerChallenge>();
    }

    // Whenever there is a collision between the food and animal we destroy both of them
    private void OnTriggerEnter(Collider other)
    {
        // If the player got hit by the animal
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.playerLives--;

            // if player lives is lower than 1 we destroy the player
            if (playerController.playerLives < 1)
            {
                Destroy(other.gameObject);
                Debug.Log("Game Over!");
            }
            Debug.Log("Lives: " + playerController.playerLives);
        }

        // if the food hits the animal we destroy the food and add to the score
        else if (other.gameObject.CompareTag("Animal"))
        {
            Destroy(this.gameObject);
        }
    }
}
