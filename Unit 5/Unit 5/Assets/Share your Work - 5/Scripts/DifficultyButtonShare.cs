using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyButtonShare : MonoBehaviour
{
    [SerializeField] private int difficulty;
    private Button button;
    private GameManagerShare gameManager;

    // Start is called before the first frame update
    void Start()
    {
        button = GetComponent<Button>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManagerShare>();

        // Whenever the button was clicked, add a listener and pass a method
        button.onClick.AddListener(SetDifficulty);
    }

    // Starting the game when the user select difficulty
   private void SetDifficulty()
    {
        Debug.Log(button.gameObject.name + " was pressed");
        gameManager.StartGame(difficulty);
    }
}