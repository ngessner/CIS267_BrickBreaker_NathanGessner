using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickSpawner : MonoBehaviour
{
    // which bricks spawn on levels
    public GameObject[] level1Bricks; 
    public GameObject[] level2Bricks; 
    public GameObject[] level3Bricks; 
    // positions for every level
    public GameObject[] level1Positions; 
    public GameObject[] level2Positions; 
    public GameObject[] level3Positions; 

    private int currentLevel;

    void Start()
    {
        randLevel();
        populateLvl();
    }

    private void randLevel()
    {
        currentLevel = Random.Range(1, 4); 
    }

    // Spawn bricks based on the selected level
    private void populateLvl()
    {        
        GameObject[] pos;
        GameObject[] bricks;

        if (currentLevel == 1)
        {
            pos = level1Positions;
            bricks = level1Bricks;
        }
        else if (currentLevel == 2)
        {
            pos = level2Positions;
            bricks = level2Bricks;
        }
        else if (currentLevel == 3)
        {
            pos = level3Positions;
            bricks = level3Bricks;
        }
        else
        {
            // just use lvl 1 as default if invalid current level
            pos = level1Positions;
            bricks = level1Bricks;
        }

        foreach (GameObject objectPos in pos)
        {
            // get random brick
            int i = Random.Range(0, bricks.Length); 
            GameObject brick = Instantiate(bricks[i], objectPos.transform.position, Quaternion.identity);            
        }
    }
}
