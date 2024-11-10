using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    public float speed = 10f; 
    public float maxScreen; 

    void Update()
    {
        move();
    }
    void move()
    {
        // get axis raw to stop weird dampening 
        float xInput = Input.GetAxisRaw("Horizontal");

        // store the position in vector 2 and store the new pos in it 
        Vector2 newPosition = transform.position;
        newPosition.x += xInput * speed * Time.deltaTime;

        // clamp the movement to prevent moving offscreen to the vector 3
        newPosition.x = Mathf.Clamp(newPosition.x, -maxScreen, maxScreen);

        // set the pos of the paddle to the new pos just made
        transform.position = newPosition;
    }
}
