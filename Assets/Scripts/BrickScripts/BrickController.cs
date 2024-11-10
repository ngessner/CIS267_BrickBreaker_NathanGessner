using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
    public int hp = 1; 
    private int points = 10;
    public float powerUpChance = 0.3f;
    public PointManager pointManager; 
    public GameObject[] powerups;

    private void Start()
    {
        // dont like these but I forgot the syntax needed
        pointManager = GameObject.Find("GUI").GetComponent<PointManager>();
    }

    public void takeDamage()
    {       
        hp--;

        if (hp <= 0)
        {
            spawnPowerupChance();
            pointManager.addPoints(points);            
            
            // destroy brick
            Destroy(gameObject);
        }
    }

    void spawnPowerupChance()
    {
        // convert 0.3 to 30, and turn into int from float.
        // this acts as our 30% chance.
        int calcChance = (int)(powerUpChance * 100);

        // if the random.range is less than the calc chance, successful powerup Instantiate
        if (Random.Range(0, 100) < calcChance)
        {
            // pick a random powerup in the array
            int randomIndex = Random.Range(0, powerups.Length);
            Instantiate(powerups[randomIndex], transform.position, Quaternion.identity);
        }
    }
}
