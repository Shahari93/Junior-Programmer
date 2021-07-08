using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.0f;
    private int score;

    [Header("Text")]
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI gameOverText = null;
    [SerializeField] private Button restartBtn = null;

    [Header("Objects to spawn")]
    [SerializeField] private List<GameObject> targets;

    [SerializeField] private GameObject titleScreen;

    public bool isGameActive;

    // Spawining game objects at X rate
    IEnumerator SpawnTarget()
    {
        // While this is true (always), run this corutine
        while (isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
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


    public void StartGame(int diffiuclty)
    {
        
        score = 0;
        isGameActive = true;

        StartCoroutine(SpawnTarget());


        /* the difficulty is 1 second divided by the difficulty number
        so the larger the difficulty number the faster objects will spawn */

        spawnRate /= diffiuclty;

        // Reseting the score at the start of the game
        UpdateScore(0);

        titleScreen.gameObject.SetActive(false);
    }


    // logic for when the game is over
    public void GameOver()
    {
        restartBtn.gameObject.SetActive(true);
        // Testing game over text
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;
    }

    // logic for when we want to restart the game
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
