using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public Hashtable paths;
    public GameObject trashPrefab;
    public GameObject meshPrefab;
    public bool canSpawnPowerup = true;

    public float cooldown;
    private bool canSpawn;
    private int current;
    public float CNDWN;


    // Start is called before the first frame update
    void Start()
    {
        cooldown = CNDWN;
        paths = new Hashtable();

        // Defining Routes:

        // ? Routes are defined based on the boolean representation
        // ? if the space between obstacles is minimum, then it would be represented correctly using
        // ? booleans to select possible and available paths.
        // ! Since, we have space between our obstacles we can test and configure difficult using
        // ! the values 5 and 6, which are 101 and 110 (only one path available)

        int[] zeroRoute = { 1, 2, 3, 5, 6 };
        int[] oneRoute = { 3, 5, 6 };
        int[] twoRoute = { 3, 5, 6 };
        int[] threeRoute = { 5, 6 };
        int[] fourRoute = { 5, 6 };
        int[] fiveRoute = { 3, 6 };
        int[] sixRoute = { 1, 2, 3, 5 };

        paths.Add(0, zeroRoute);
        paths.Add(1, oneRoute);
        paths.Add(2, twoRoute);
        paths.Add(3, threeRoute);
        paths.Add(4, fourRoute);
        paths.Add(5, fiveRoute);
        paths.Add(6, sixRoute);

        // Route 4 (100) is not used since makes the game easier.

        StartSpawn();
        current = 0;
    }

    // disable spawn
    public void StopSpawn()
    {
        canSpawn = false;
    }

    // enable spawn
    public void StartSpawn()
    {
        canSpawn = true;
    }

    // spawn a new structure.
    void SpawnNewStructure()
    {
        // Check available routes
        int[] routes = (int[]) paths[current];

        // Select new obstacle
        current = routes[Random.Range(0, routes.Length)];

        // Spawn Obstacle
        Spawn(current);
    }

    // spawn the path
    void Spawn(int option)
    {
        switch(option) {
            case 1:
                GameObject a = Create(-2.25f);
                SpawnPowerUp();
                break;
            case 2:
                if (!SpawnPowerUp()) {
                    GameObject b = Create(0.0f);
                }
                break;
            case 3:
                GameObject c = Create(-2.25f);
                if (!SpawnPowerUp()) {
                    GameObject d = Create(0f);
                }
                break;
            case 4:
                GameObject e = Create(2.25f);
                SpawnPowerUp();
                break;
            case 5:
                GameObject f = Create(2.25f);
                GameObject g = Create(-2.25f);
                SpawnPowerUp();
                break;
            case 6:
                GameObject h = Create(2.25f);
                if (!SpawnPowerUp()) {
                    GameObject i = Create(0.0f);
                }
                break;
        }
    }

    // check if we can spawn power up
    bool SpawnPowerUp() {
        if (canSpawnPowerup) {
            // select a random number
            int ratio = Random.Range(0, 100);

            // if random number is greater than expected we can spawn.
            if (ratio > 80) {
                canSpawnPowerup = false;

                GameObject pw = Instantiate(meshPrefab) as GameObject;
                pw.transform.position = new Vector2(10, 0);

                return true;
            }
        }

        return false;
    }

    // Function to create trash
    GameObject Create(float positionY) {
        GameObject a = Instantiate(trashPrefab) as GameObject;
        a.transform.position = new Vector2(10, positionY);

        return a;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn) {
            if (cooldown <= 0) {
                // spawn a new structure
                SpawnNewStructure();

                // Restart timer
                cooldown = CNDWN;
            } else {
                cooldown -= Time.deltaTime;
            }
        }
    }
}
