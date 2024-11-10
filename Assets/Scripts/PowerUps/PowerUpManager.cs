using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    public GameObject ballPrefab;
    public GameObject ballSpawnPos;
    public float largeBallScale = 1.5f;
    public float shrinkBallScale = .5f;
    private Vector2 originalBallScale;  

    void Start()
    {
        GameObject ball = GameObject.FindWithTag("Ball");
        ballSpawnPos = GameObject.Find("BallSpawnLocation");
        originalBallScale = ball.transform.localScale;        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // if the power up hits the player
        if (other.CompareTag("Player"))
        {
            // activate it
            activatePower();

            // and destroy it. Game manager will handle the cooldown delays from here.
            Destroy(gameObject);
        }
    }

    void activatePower()
    {
        // power up if chain
        if (CompareTag("MultiBall"))
        {
            spawnBall();
        }
        else if (CompareTag("LargeBall"))
        {
            largeBallBuff();
        }
        else if (CompareTag("ShrinkBall"))
        {
            smallBallNerf();
        }
    }
    void spawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, ballSpawnPos.transform.position, Quaternion.identity);
    }

    void largeBallBuff()
    {
        GameObject ball = GameObject.FindWithTag("Ball");
        // scale up
        ball.transform.localScale = originalBallScale * largeBallScale;
    }
    void smallBallNerf()
    {
        GameObject ball = GameObject.FindWithTag("Ball");
        // scale down
        ball.transform.localScale = originalBallScale * shrinkBallScale;
    }
}
