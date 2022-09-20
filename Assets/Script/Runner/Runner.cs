using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Runner : MonoBehaviour
{
    private bool gameRunning;
    private bool isPaused;
    public int score;
    private VerticalPlayer player;
    private SpawnObstacles spawn;

    public GameObject uiPanel;
    public GameObject pausePanel;
    public GameObject losePanel;

    private TMP_Text uiScore;
    private TMP_Text uiLives;
    public Text loseScore;

    // Start is called before the first frame update
    void Start()
    {
        isPaused = false;
        gameRunning = true;
        score = 0;

        player = GameObject.Find("Player").GetComponent<VerticalPlayer>();
        spawn = GetComponent<SpawnObstacles>();

        uiScore = GameObject.Find("Text Score").GetComponent<TMP_Text>();
        uiLives = GameObject.Find("Text Lives").GetComponent<TMP_Text>();
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

            loseScore.text = score.ToString();

            uiScore.SetText(score.ToString());
            uiLives.SetText("Vidas: " + player.lives.ToString());
        }

        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (isPaused) {
                UnPause();
                ShowUI();
            } else {
                Pause();
                HideUI();
            }
        }
    }

    // Pause the game
    public void Pause()
    {
        gameRunning = false;
        isPaused = true;
        Time.timeScale = 0f;
        spawn.StopSpawn();
        pausePanel.SetActive(true);
    }

    public void UnPause()
    {
        gameRunning = true;
        isPaused = false;
        Time.timeScale = 1f;
        spawn.StartSpawn();
        pausePanel.SetActive(false);
    }

    public void GameOver()
    {
        gameRunning = false;
        spawn.StopSpawn();
        losePanel.SetActive(true);
    }

    public void HideUI()
    {
        uiPanel.SetActive(false);
    }

    public void ShowUI()
    {
        uiPanel.SetActive(true);
    }

    public void AddPoints(int point) {
        score += point;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MinigamesMenu");
    }

    public void QuitGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
