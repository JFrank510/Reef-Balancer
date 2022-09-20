using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    private bool gameRunning;
    public int score;
    private VerticalPlayer player;
    private SpawnObstacles spawn;

    // Start is called before the first frame update
    void Start()
    {
        gameRunning = true;
        score = 0;

        player = GameObject.Find("Player").GetComponent<VerticalPlayer>();
        spawn = GetComponent<SpawnObstacles>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is alive
        if (gameRunning) {

            if (player.lives <= 0) {
                gameRunning = false;
                HideUI();
                GameOver();

                Destroy(player.gameObject);
            }

        }
    }

    // Pause the game
    public void Pause()
    {
        gameRunning = false;
        spawn.StopSpawn();
    }

    public void GameOver()
    {
        gameRunning = false;
        spawn.StopSpawn();
    }

    public void HideUI()
    {

    }

    public void ShowUI()
    {

    }

    public void AddPoints(int point) {
        score += point;
    }
}
