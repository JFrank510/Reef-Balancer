using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This is the class in charge of creating the spawn of our fish (where they spawn, where the spawn limits are and how many spawn they spawn), it maintains the idea of ​​another script used 
// in spaceInvaders but this one has changes since three new mechanics are added, the first generate a random amount of fish, the second is to be able to spawn different types of species 
// and the last is that this script is executed by another script.

// Variables:
// LionFishPrefabQ: This variable stores all the properties of a species of a fish. Because the main idea is to save resources, plus if we don't know what a fish will do, 
// we can clone it and it will do its task in the fish script, these properties are more detailed.

// GreenFishPrefabQ: This variable stores all the properties of a species of a fish. It keeps the same idea of ​​the LionFishPrefabQ variable.

// PinkFishPrefabQ: This variable stores all the properties of a species of a fish. Keeps the same idea of ​​the LionFishPrefabQ variable

// spawnGFQ, spawnPFQ, spawnLFQ : control variables used to know how many fish of each species are going to spawn.

// screenBounds: Variable responsible for maintaining the limit of where the fish spawn, in addition to the fact that one of the properties of the fish is to move in the environment, 
// this also helps us to limit that movement limit and always be in view of the player.

// Methods:

// Start() method

// The main idea is to initialize the spawn limit.

// Why the Start() method

// Start is called in the framework when a script is enabled just before any of the Update methods are called for the first time.
// Like the Awake function, Start is called exactly once during the lifetime of the script. However, Awake is called when the script object is initialized, regardless 
// of whether scripting is enabled or not. Start may not be called in the same frame as Wake if the script is not enabled at initialization time.

// DoSpawn() Method

// The idea is to get this method to serve as a trigger for the spawn (that when a condition or time limit is met, it is triggered) that is why it is made up of other methods 
// (RandomSpawn, spawnTypesFishes) that make it possible to serve as a trigger.

// RandomSpawn() method

// Function that generates a random number for each species to spawn.

// spawnLionFish, spawnGreenFish, spawnPinkFish() method
// The idea is to obtain the object of each type of fish species since here we can access the properties that each one has and be able to clone it and position it in an initial position.

// spawnTypesFishes() method
// This will be the function that will paint the fish in the main camera of our game, since at this point we already have the object instantiated and ready to manipulate it.
public class SpawnerFishesQ : MonoBehaviour
{
    public GameObject LionFishPrefabQ;
    public GameObject GreenPrefabQ;
    public GameObject PinkFishPrefabQ;
    public GameObject BlueFishPrefabQ;
    private Vector2 screenBounds;
    public int spawnBFQ,spawnGFQ, spawnPFQ, spawnLFQ,spawnTypeNumber;
    public List<int> listNumbersSpawn = new List<int>();
    private System.Random random = new System.Random();

    private void Start() {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    public void DoSpawn()        
    {
        RandomSpawn();
        spawnTypesFishes();
    }
    public void RandomNumberSpawn()
    {
        for (int i = 0; i < 4; i++)
        {
            do {
                spawnTypeNumber = random.Next(1, 5);
            } while (listNumbersSpawn.Contains(spawnTypeNumber));
            listNumbersSpawn.Add(spawnTypeNumber);
        }
    }

    public void RandomSpawn()
    {
        RandomNumberSpawn();
        spawnLFQ =  listNumbersSpawn[0];
        spawnGFQ =  listNumbersSpawn[1];
        spawnPFQ =  listNumbersSpawn[2];
        spawnBFQ =  listNumbersSpawn[3];
    }
    private void spawnLionFish()
    {
        GameObject a = Instantiate(LionFishPrefabQ) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x + 2 , screenBounds.x - 2), Random.Range(0, screenBounds.y));
    }
    private void spawnGreenFish()
    {
        GameObject b = Instantiate(GreenPrefabQ) as GameObject;
        b.transform.position = new Vector2(Random.Range(-screenBounds.x + 2 , screenBounds.x - 2), Random.Range(0, screenBounds.y));
    }
    private void spawnPinkFish()
    {
        GameObject c = Instantiate(PinkFishPrefabQ) as GameObject;
        c.transform.position = new Vector2(Random.Range(-screenBounds.x + 2 , screenBounds.x - 2), Random.Range(0, screenBounds.y));
    }

    private void spawnBlueFish()
    {
         GameObject d = Instantiate(BlueFishPrefabQ) as GameObject;
        d.transform.position = new Vector2(Random.Range(-screenBounds.x + 2 , screenBounds.x - 2), Random.Range(0, screenBounds.y));
    }

    private void spawnTypesFishes()
    {
        for (int i = 0; i < spawnLFQ; i++) {
            spawnLionFish();
        }

        for (int j = 0; j < spawnGFQ; j++) {
            spawnGreenFish();
        }

        for (int k = 0; k < spawnPFQ; k++) {
            spawnPinkFish();
        }

        for (int k = 0; k < spawnBFQ; k++) {
            spawnBlueFish();
        }
    }

}
