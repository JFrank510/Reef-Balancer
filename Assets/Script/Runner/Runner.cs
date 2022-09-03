using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Runner : MonoBehaviour
{
    private bool gameRunning;
    private float structureCooldown = 5.0f;
    private VerticalPlayer player;
    public Hashtable paths;

    // Start is called before the first frame update
    void Start()
    {
        gameRunning = true;

        player = GameObject.Find("Player").GetComponent<VerticalPlayer>();

        paths = new Hashtable();
        float[] values =  new float[10];
        paths.Add(0, values);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if player is alive
        if (player.lives <= 0) {
            gameRunning = false;
            HideUI();
            GameOver();
        }

        if (gameRunning) {
            if (structureCooldown <= 0) {
                // Select next structure
                        
                // Create Structure

                structureCooldown = 5.0f;
            } else {
                structureCooldown -= Time.deltaTime;
            }
        }
    }

    // Pause the game
    public void Pause()
    {
        gameRunning = false;
    }

    public void GameOver()
    {
        gameRunning = false;
    }

    public void HideUI()
    {

    }

    public void ShowUI()
    {

    }
}
