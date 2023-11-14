using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    // Spawning the prefab
    public GameObject obstacalPrefab;
    // setting position of prefab
    private Vector3 spawnPos = new Vector3(30, 1.5f, 0);
    // access player controller 
    private PlayerController playerControllerScript;

    private float startDelay = 2;
    private float repeatRate = 2;
    // Start is called before the first frame update
    void Start()
    {
        // "Player" is looking for the literal name of the player
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        // method name, time, repeat
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnObstacle ()
    {
        // stops spawning objects when game is over 
        if(playerControllerScript.gameOver == false)
        {
        // make a copy of the prefab
        Instantiate(obstacalPrefab, spawnPos, obstacalPrefab.transform.rotation);
        }
    }
}
