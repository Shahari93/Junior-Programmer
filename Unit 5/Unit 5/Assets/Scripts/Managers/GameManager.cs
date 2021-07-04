using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    WaitForSeconds waitSpawn = new WaitForSeconds(1.0f);
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private List<GameObject> targets;
    private int score;


    void Start()
    {
        StartCoroutine(SpawnTarget());
        //score = 0;

        // Reseting the score at the start of the game
        UpdateScore(0);
    }

    // Spawining game objects at X rate
    IEnumerator SpawnTarget()
    {
        // While this is true (always), run this corutine
        while (true)
        {
            yield return waitSpawn;
            int randTarget = Random.Range(0, targets.Count);
            Instantiate(targets[randTarget]);
        }
    }

    // Updating the score method
    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        // Assigning the score int to the score text
        scoreText.text = "Score: " + score;
    }
}
