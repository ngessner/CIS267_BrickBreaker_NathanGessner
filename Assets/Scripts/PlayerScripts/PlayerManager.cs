using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public GameOverManager gameOver;
    public TextMeshProUGUI livesTMP;
    public PointManager pointManager;

    public int lives = 3;
    public Transform ballSpawnLoc; 

    public GameObject ballPrefab;

    private void Start()
    {
        pointManager = GameObject.Find("GUI").GetComponent<PointManager>();
        updateLivesTmp();
    }

    // call this whenever the ball falls out of bounds.
    public void loseLife()
    {
        lives--;
        updateLivesTmp();

        if (lives <= 0)
        {
            endGame();
        }
        else
        {
            respawnBall();
        }
    }

    private void updateLivesTmp()
    {
        livesTMP.text = "" + lives;
    }

    void endGame()
    {
        int finalScore = pointManager.getPoints(); 
        gameOver.showGameOver(finalScore);
    }

    private void respawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, ballSpawnLoc.position, Quaternion.identity);
    }
}
