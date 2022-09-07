using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public Hashtable paths;
    public float cooldown = 5.0f;
    private bool canSpawn;
    private int current;

    // Start is called before the first frame update
    void Start()
    {
        paths = new Hashtable();

        // Defining Routes:
        int[] zeroRoute = {0, 1, 2, 3, 4, 5, 6};
        int[] oneRoute = {0, 1, 2, 3, 5};
        int[] twoRoute = {0, 1, 2, 3, 4, 6};
        int[] threeRoute = {0, 1, 2, 3};
        int[] fourRoute = {0, 1, 2, 4, 5, 6};
        int[] fiveRoute = {0, 1, 4, 5};
        int[] sixRoute = {0, 2, 4, 6};

        paths.Add(0, zeroRoute);
        paths.Add(1, oneRoute);
        paths.Add(2, twoRoute);
        paths.Add(3, threeRoute);
        paths.Add(4, fourRoute);
        paths.Add(5, fiveRoute);
        paths.Add(6, sixRoute);

        StartSpawn();
        current = 0;
    }

    void StopSpawn()
    {
        canSpawn = false;
    }

    void StartSpawn()
    {
        canSpawn = true;
    }

    void SpawnNewStructure()
    {
        // Check available routes
        int[] routes = (int[]) paths[current];

        // Select new obstacle
        current = routes[Random.Range(0, routes.Length)];

        // Spawn Obstacle
        Debug.Log(current);
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn) {
            if (cooldown <= 0) {
                SpawnNewStructure();

                // Restart timer
                cooldown = 5.0f;
            } else {
                cooldown -= Time.deltaTime;
            }
        }
    }
}
