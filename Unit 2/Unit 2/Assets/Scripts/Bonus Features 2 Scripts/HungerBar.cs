using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HungerBar : MonoBehaviour
{
    [SerializeField] Image hungerBarFill = null;
    [SerializeField] public int howHungrey = 0;
    [SerializeField] public int howManyFood = 0;
    public PlayerControllerChallenge playerController;

    private void Start()
    {
        howHungrey = Random.Range(1, 4);
        playerController = FindObjectOfType<PlayerControllerChallenge>();

    }

    private void OnTriggerEnter(Collider other)
    {
        // If the food hits the animal we fill the hunger bar
        if (other.gameObject.CompareTag("Food"))
        {
            howManyFood++;
            hungerBarFill.fillAmount += 1.0f / howHungrey * howManyFood;

            // if the player feed the animal the right amount of food we destroy the animal
            if (howManyFood >= howHungrey)
            {
                playerController.playerScore++;
                Debug.Log("Score: " + playerController.playerScore);
                Destroy(gameObject);
            }
        }
    }
}
