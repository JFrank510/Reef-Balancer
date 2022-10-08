using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HideNSeek : MonoBehaviour
{
    public GameObject CaughtPrefab;
    public GameObject MovePrefab;
    public GameObject pausePanel;
    public GameObject uiPanel;
    public GameObject losePanel;
    public GameObject winPanel;
    
    private TMP_Text timer;
    private TMP_Text uiScore;
    public Text loseScore;
    public Text winScore;

    public UnityEngine.Rendering.Universal.Light2D lt;
    public bool isNight;
    private bool isPaused = false;
    private Vector2 screenBounds;
    private float ctdnw = 61.0f;

    public int maximum = 12;
    public int score = 0;
    public int remainingFishes;

    // Start is called before the first frame update
    void Start()
    {
        Resume();
        // Set UI active
        uiPanel.SetActive(true);
        losePanel.SetActive(false);
        winPanel.SetActive(false);
        pausePanel.SetActive(false);

        // get the ui text
        timer = GameObject.Find("Text Timer").GetComponent<TMP_Text>();
        uiScore = GameObject.Find("Text Score").GetComponent<TMP_Text>();
        
        // get the light component
        lt = this.transform.GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        // check boundaries
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // create fishes and obstacles between boundaries.
        for (int i = 0; i < maximum; i++) {
            // @TODO: we need more dispersion
            float positionX = Random.Range(-screenBounds.x + 1, screenBounds.x - 1);
            float positionY = Random.Range(-1f, screenBounds.y - 1);

            CreateFish(positionX, positionY);
            CreateObstacle(positionX, positionY);
        }

        remainingFishes = maximum;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(isPaused) {
                uiPanel.SetActive(true);
                pausePanel.SetActive(false);
                Resume();
            } else{
                uiPanel.SetActive(false);
                pausePanel.SetActive(true);
                Pause();
            } 
        }

        if (remainingFishes == 0) {
            Pause();
            uiPanel.SetActive(false);
            winPanel.SetActive(true);
        }

        // timer reduce time
        if (ctdnw > 0) {
            ctdnw -= Time.deltaTime;
        }

        // timer is 0 or less
        if (ctdnw <= 0) {
            Pause();
            uiPanel.SetActive(false);
            losePanel.SetActive(true);
        }

        // set the second correctly in text
        int b = (int) System.Math.Round(ctdnw, 2);

        timer.SetText(b.ToString());
        uiScore.SetText(score.ToString());
        loseScore.text = score.ToString();
        winScore.text = score.ToString();

        // if time is less than 30 seconds
        if (ctdnw < 30) {
            // activate night
            isNight = true;
            lt.intensity = 0.2f;
        }
    }

    private void CreateFish(float positionX, float positionY)
    {
        GameObject a = Instantiate(CaughtPrefab) as GameObject;
        a.transform.position = new Vector2(positionX, positionY);
    }

    private void CreateObstacle(float positionX, float positionY)
    {
        GameObject b = Instantiate(MovePrefab) as GameObject;
        b.transform.position = new Vector2(positionX, positionY);
    }

    public void UpdateScore(double points)
    {
        score += (int) (points * (ctdnw / 2));
    }

    private void Resume()
    {
        Time.timeScale = 1f;
        isPaused = false;
    }

    private void Pause()
    {
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        uiPanel.SetActive(true);
        pausePanel.SetActive(false);
        Resume();
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Resume();
    }
}
