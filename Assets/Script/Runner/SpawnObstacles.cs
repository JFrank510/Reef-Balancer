using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public Hashtable paths;
    public GameObject trashPrefab;
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
        int[] zeroRoute = { 1, 2, 3, 4, 5, 6};
        int[] oneRoute = { 1, 2, 3, 5};
        int[] twoRoute = { 1, 2, 3, 4, 6};
        int[] threeRoute = { 1, 2, 3};
        int[] fourRoute = { 1, 2, 4, 5, 6};
        int[] fiveRoute = { 1, 4, 5};
        int[] sixRoute = { 2, 4, 6};

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

    public void StopSpawn()
    {
        canSpawn = false;
    }

    public void StartSpawn()
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
        Spawn(current);
    }

    void Spawn(int option)
    {
        switch(option) {
            case 1:
                GameObject a = Create(-2.25f);
                break;
            case 2:
                GameObject b = Create(0.0f);
                break;
            case 3:
                GameObject c = Create(-2.25f);
                GameObject d = Create(0f);
                break;
            case 4:
                GameObject e = Create(2.25f);
                break;
            case 5:
                GameObject f = Create(2.25f);
                GameObject g = Create(-2.25f);
                break;
            case 6:
                GameObject h = Create(2.25f);
                GameObject i = Create(0.0f);
                break;
        }
    }

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
                SpawnNewStructure();

                // Restart timer
                cooldown = CNDWN;
            } else {
                cooldown -= Time.deltaTime;
            }
        }
    }
}
