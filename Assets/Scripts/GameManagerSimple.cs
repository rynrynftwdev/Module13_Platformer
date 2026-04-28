using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

//Global manager for score and UI
//Create an empty GameObject and attach this script
//Assign scoreText in the inspector
public class GameManagerSimple : MonoBehaviour
{
    //Create a singleton loop: Create an instance of this object and point it to itself
    public static GameManagerSimple Instance;

    //Define UI elements
    [Header("UI")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI messageText;


    //Define Global Variables
    public int score = 0;
    private bool gameOver = false;


    //Simple singleton loop using void Awake()
    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        UpdateScoreUI();
        ShowMessage(""); //Empty at the start
    }

    // Update is called once per frame
    void Update()
    {
        //Handle Win/Lose conditions and Restart
        if (gameOver && Input.GetKeyDown(KeyCode.R))
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
    //Void to add score
    public void AddScore(int amount)
    {
        if (gameOver) return;
        score += amount;
        //Call method to update the UI
        UpdateScoreUI();
    }

    //Void to show message
    public void ShowMessage(string msg)
    {
        if (messageText.text != null) messageText.text = msg;
    }

    //Void to win
    public void Win()
    {
           gameOver = true;
           ShowMessage("YOU WIN!!! :D Press R to Restart");
           //set time scale to 0 to pause until restart
           Time.timeScale = 0f;

    }

    //Void to lose
    public void Lose()
    {
        gameOver = true;
        ShowMessage("Game Over! D: Press R to Restart");
        //set time scale to 0 to pause until restart
        Time.timeScale = 0f;
    }   

    //Void to update the UI
    private void UpdateScoreUI()
    {
        if (scoreText != null) scoreText.text = "Score: " + score;
    }   
}
