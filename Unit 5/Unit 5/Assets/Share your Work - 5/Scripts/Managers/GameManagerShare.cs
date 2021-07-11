using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManagerShare : MonoBehaviour
{
    private float spawnRate = 1.0f;
    private int score;
    public int lives;

    [Header("UI")]
    [SerializeField] private TextMeshProUGUI scoreText = null;
    [SerializeField] private TextMeshProUGUI livesText = null;
    [SerializeField] private TextMeshProUGUI gameOverText = null;
    [SerializeField] private Button restartBtn = null;
    [SerializeField] private Slider musicVol;

    [Header("Objects to spawn")]
    [SerializeField] private List<GameObject> targets;

    [SerializeField] private GameObject titleScreen;
    [SerializeField] private GameObject pauseScreen;
    [SerializeField] private AudioSource music;

    public bool isGameActive;
    public bool isGamePaused = false;

    private void Awake()
    {
        SetVol();
    }

    private void Update()
    {
        SetVol();
        PauseGame();
    }

    private void SetVol()
    {
        music.volume = musicVol.value;
    }


    private void PauseGame()
    {
        if (isGameActive)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                isGamePaused = !isGamePaused;
                if(isGamePaused)
                {
                    Time.timeScale = 0f;
                    pauseScreen.SetActive(true);
                }
                else
                {
                    Time.timeScale = 1f;
                    pauseScreen.SetActive(false);
                }
            }
        }
    }

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

    public void UpdateLives(int livesToReduce)
    {
        if (lives > 0)
        {
            lives -= livesToReduce;
            livesText.text = "Lives: " + lives;
        }
    }

    public void StartGame(int diffiuclty)
    {

        score = 0;
        lives = 3;
        isGameActive = true;

        StartCoroutine(SpawnTarget());


        /* the difficulty is 1 second divided by the difficulty number
        so the larger the difficulty number the faster objects will spawn */

        spawnRate /= diffiuclty;

        // Reseting the score at the start of the game
        UpdateScore(0);
        UpdateLives(0);
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
