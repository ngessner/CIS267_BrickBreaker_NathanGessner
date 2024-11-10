using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverUI;
    public TextMeshProUGUI scoreText; 

    public void showGameOver(int score)
    {
        gameOverUI.SetActive(true); 
        scoreText.text = "" + score; 
        // pause the game
        Time.timeScale = 0f; 
    }

    public void playAgain()
    {
        // unpuase the game
        Time.timeScale = 1f; 
        SceneManager.LoadScene("SampleScene"); 
    }

    public void quitMainMenu()
    {
        Time.timeScale = 1f; 
        SceneManager.LoadScene("MainMenu"); 
    }
}
