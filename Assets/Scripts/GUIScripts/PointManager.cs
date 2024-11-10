using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PointManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText; 
    private int score = 0; 

   // add points
    public void addPoints(int points)
    {
        score += points;
        updateScore();
    }

    // get points for game over screen
    public int getPoints()
    {
        return score;
    }

    void updateScore()
    {     
        scoreText.text = "" + score;        
    }
}
