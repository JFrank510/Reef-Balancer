using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This class is responsible for creating the spawn of our fish.
//(where they spawn, where are the spawn limits and how many spawn)

//Variables
// LionFishPrefab: This variable stores all the properties of a fish. Because the main idea is to save resources, 
// in addition to the fact that if we don't know what a fish will do, we can clone it and it will perform its 
// task in the fish script, these properties are more detailed.

//screenBounds: Variable in charge of keeping the limit of where the fish will spawn, in addition to the fact that one 
// of the properties of the fish is to move in the environment, this also helps us to limit that movement limit and always be in view of the player.

//maximum: control variable used to know how many fish spawn

//Method Start

//the main idea is to initialize the spawn limit and the method that spawns our fish

//Why method Start()

//Start is called on the frame when a script is enabled just before any of the Update methods are called the first time.
// Like the Awake function, Start is called exactly once in the lifetime of the script. However, Awake is called when the script 
// object is initialised, regardless of whether or not the script is enabled. Start may not be called on the same frame as 
// Awake if the script is not enabled at initialisation time.

//Method spawnEnemy

//The idea is to obtain the class of the creation of a fish since here we can access the properties that it has and be able to clone it.

//Method createMock

//Function that clones the fish.
public class InitializeMock : MonoBehaviour
{
    public GameObject LionFishPrefab;
    private Vector2 screenBounds;
    
    public int maximum = 10;

    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        createMock();
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(LionFishPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x + 2 , screenBounds.x - 2), Random.Range(0, screenBounds.y));
    }

    private void createMock()
    {
        for (int i = 0; i < maximum; i++) {
            spawnEnemy();
        }
    }
}
