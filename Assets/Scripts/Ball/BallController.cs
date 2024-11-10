using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float ballSpeed = 5f; 
    public float delayTime = 1.5f;  
    PlayerManager player;
    private Rigidbody2D rb;

    private float timer = 0f; 
    private bool ballLaunched = false; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindWithTag("Player").GetComponent<PlayerManager>();
    }

    void Update()
    {
        launchBallTimer();
    }

    void launchBallTimer()
    {
        if (!ballLaunched)
        {
            timer += Time.deltaTime;

            if (timer >= delayTime)
            {
                launchBall();
                ballLaunched = true;
            }
        }
    }

    void launchBall()
    {
        // random x direction to shoot in
        float randX = Random.Range(-1f, 1f);

        // -1 for downwards
        float y = -1f;

        // store in vector
        Vector2 initDir = new Vector2(randX, y).normalized;
        rb.velocity = initDir * ballSpeed;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // hit pos based on horizontal diff
        float hit = (transform.position.x - collision.transform.position.x) / collision.collider.bounds.size.x;
        float verticalDirection;

        // determine verticale dir based on collision type
        if (collision.gameObject.CompareTag("Player"))
        {
            // up if player (paddle)
            verticalDirection = 1f; 
        }
        else
        {
            // down if object
            verticalDirection = -1f; 
        }

        // store new dir to send the ball in under the balls selected speed.
        Vector2 newDirection = new Vector2(hit, verticalDirection).normalized;
        rb.velocity = newDirection * ballSpeed;

        if (collision.gameObject.CompareTag("Brick"))
        {
            BrickController brick = collision.gameObject.GetComponent<BrickController>();    
            
            // dont need != null because of the tag, if it has that tag it has this script.
            brick.takeDamage();         
        }

        if (collision.gameObject.CompareTag("DeathBox"))
        {               
            if (CompareTag("CopiedBall"))
            {
                Destroy(this.gameObject);

            }
            else if (CompareTag("Ball"))
            {
                player.loseLife();

                // destroy ball we're intantiating a new one
                Destroy(this.gameObject);
            }
        }
    }
}
