using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Quiz : MonoBehaviour, IDataPersistence
{
    public GameObject uiPanel;
    public GameObject losePanel;
    public GameObject pausePanel;
    public GameObject questionPanel;

    public GameObject fishPrefab;

    public TMP_Text btnLU;
    public TMP_Text btnLD;
    public TMP_Text btnRU;
    public TMP_Text btnRD;

    public Sprite[] sprites;
    public float[]  scales;

    public int[] answers;
    public int correctAnswer;
    public GameObject correctSprite;
    public int round = 0;

    public bool isQuestionDisplay;
    public bool isAnswerCorrect;
    public float cndwn = 10.0f;
    public int score = 0;

    private Vector2 screenBounds;

    private TMP_Text uiTimer;
    private TMP_Text uiRound;
    private TMP_Text uiScore;
    public Text loseScore;

    public bool isPaused = false;
    public int coralCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        
        uiTimer = GameObject.Find("Text Timer").GetComponent<TMP_Text>();
        uiRound = GameObject.Find("Text Round").GetComponent<TMP_Text>();
        uiScore = GameObject.Find("Text Score").GetComponent<TMP_Text>();

        answers = new int[4];
        Session();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isPaused) {
            cndwn -= Time.deltaTime;
            uiTimer.SetText("Tiempo restante\n" + ((int) System.Math.Round(cndwn, 2)).ToString());
        }

        if (cndwn < 0 && isQuestionDisplay) {
            if (!isAnswerCorrect) {
                GameOver();
            } else {
                Session();
            }
        } else if (cndwn < 0 && !isQuestionDisplay) {
            QuestionDisplay();
        }

        if (Input.GetKeyDown(KeyCode.Escape) && isQuestionDisplay)
        {
            if (isPaused) {
                Resume();
            } else {
                Pause();
            }
        }
    }

    void Session()
    {
        uiPanel.SetActive(true);
        losePanel.SetActive(false);
        questionPanel.SetActive(false);
        pausePanel.SetActive(false);

        isQuestionDisplay = false;
        isAnswerCorrect   = false;
        round++;
        uiRound.SetText("Ronda: " + round.ToString());
        
        CreateMock();
        SelectAnswer();
        SelectSpecies();
        SetAnswers();

        cndwn = 10.0f;
    }

    void CreateMock()
    {
        int n = Random.Range(4, 7);
        int fuzz = Random.Range(2, 4);

        answers[0] = (n - fuzz);
        answers[1] = (n + fuzz);
        answers[2] = (n);
        answers[3] = (n + (Random.Range(0, 100) > 50 ? 1 : -1));
    }

    void SelectAnswer()
    {
        int index = Random.Range(0, 4);

        correctAnswer = answers[index];
    }

    void SelectSpecies()
    {
        int max = sprites.Length;
        int n   = Random.Range(0, max);
        int j   = 0;

        for (int i = n; i >= 0; i--) {
            RenderFish(sprites[i], answers[j], i);
            j++;
        }

        for (int i = n + 1; i < max; i++) {
            RenderFish(sprites[i], answers[j], i);
            j++;
        }
    }

    void RenderFish(Sprite sp, int quantity, int index)
    {
        if (quantity == correctAnswer) {
            correctSprite.GetComponent<Image>().sprite = sp;
        }

        for (int i = 0; i < quantity; i++) {
            GameObject a = Instantiate(fishPrefab) as GameObject;
            
            a.name = "Fish";

            a.GetComponent<SpriteRenderer>().sprite = sp;
            a.transform.position = new Vector3(Random.Range(-screenBounds.x + 2 , screenBounds.x - 2), Random.Range(0, screenBounds.y), -2);
            
            a.transform.localScale = new Vector3(scales[index], scales[index], scales[index]);

            if (index == 1 || index == 3) {
                a.GetComponent<Fish>().Flip();
            }
        }
    }

    void SetAnswers()
    {
        ButtonInteractive btn1 = btnLU.GetComponent<ButtonInteractive>();
        ButtonInteractive btn2 = btnRU.GetComponent<ButtonInteractive>();
        ButtonInteractive btn3 = btnLD.GetComponent<ButtonInteractive>();
        ButtonInteractive btn4 = btnRD.GetComponent<ButtonInteractive>();

        btn1.setText(answers[0].ToString());
        btn1.setValue(answers[0]);

        btn2.setText(answers[1].ToString());
        btn2.setValue(answers[1]);

        btn3.setText(answers[2].ToString());
        btn3.setValue(answers[2]);

        btn4.setText(answers[3].ToString());
        btn4.setValue(answers[3]);
    }

    public void BtnLUCompare()
    {
        ButtonInteractive btn1 = btnLU.GetComponent<ButtonInteractive>();

        if (btn1.isCorrect(correctAnswer)) {
            CorrectAnswerUpdate();
            DisableButtons();
            btn1.setCorrect();
            isAnswerCorrect = true;
        } else {
            btn1.setIncorrect();
            ShowCorrectAnswer();
        }

        cndwn = 5.0f;
    }

    public void BtnRUCompare()
    {
        ButtonInteractive btn1 = btnRU.GetComponent<ButtonInteractive>();

        if (btn1.isCorrect(correctAnswer)) {
            CorrectAnswerUpdate();
            DisableButtons();
            btn1.setCorrect();
            isAnswerCorrect = true;
        } else {
            btn1.setIncorrect();
            ShowCorrectAnswer();
        }

        cndwn = 5.0f;
    }

    public void BtnLDCompare()
    {
        ButtonInteractive btn1 = btnLD.GetComponent<ButtonInteractive>();

        if (btn1.isCorrect(correctAnswer)) {
            CorrectAnswerUpdate();
            btn1.setCorrect();
            isAnswerCorrect = true;
            DisableButtons();
        } else {
            btn1.setIncorrect();
            ShowCorrectAnswer();
        }

        cndwn = 5.0f;
    }

    public void BtnRDCompare()
    {
        ButtonInteractive btn1 = btnRD.GetComponent<ButtonInteractive>();

        if (btn1.isCorrect(correctAnswer)) {
            CorrectAnswerUpdate();
            btn1.setCorrect();
            isAnswerCorrect = true;
            DisableButtons();
        } else {
            btn1.setIncorrect();
            ShowCorrectAnswer();
        }

        cndwn = 5.0f;
    }

    void CorrectAnswerUpdate()
    {
        int points = 100 * (int) System.Math.Round(cndwn, 2);

        score += points;

        uiScore.SetText(score.ToString());
        loseScore.text = score.ToString();
    }

    void DisableButtons()
    {
        btnLU.GetComponent<ButtonInteractive>().Disable();
        btnRU.GetComponent<ButtonInteractive>().Disable();
        btnLD.GetComponent<ButtonInteractive>().Disable();
        btnRD.GetComponent<ButtonInteractive>().Disable();
    }

    void ShowCorrectAnswer()
    {
        ButtonInteractive btn;

        DisableButtons();

        if (answers[0] == correctAnswer) {
            btn = btnLU.GetComponent<ButtonInteractive>();
        } else if (answers[1] == correctAnswer) {
            btn = btnRU.GetComponent<ButtonInteractive>();
        } else if (answers[2] == correctAnswer) {
            btn = btnLD.GetComponent<ButtonInteractive>();
        } else {
            btn = btnRD.GetComponent<ButtonInteractive>();
        }

        btn.setCorrect();
    }

    void Pause()
    {
        uiPanel.SetActive(false);
        questionPanel.SetActive(false);
        pausePanel.SetActive(true);
        isPaused = true;
        Time.timeScale = 0f;
    }

    public void Resume()
    {
        pausePanel.SetActive(false);
        uiPanel.SetActive(true);

        if (isQuestionDisplay) {
            questionPanel.SetActive(true);
        }

        isPaused = false;
        Time.timeScale = 1f;
    }

    void GameOver()
    {
        uiPanel.SetActive(false);
        questionPanel.SetActive(false);
        losePanel.SetActive(true);
    }

    void QuestionDisplay()
    {
        cndwn = 10;
        isQuestionDisplay = true;

        questionPanel.SetActive(true);
    }

    void DebugRound()
    {
        Debug.Log(
            round.ToString() + " - " +
            answers[0].ToString() + "," +
            answers[1].ToString() + "," +
            answers[2].ToString() + "," +
            answers[3].ToString() + ","
        );
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

    public void scoreToCoins()
    {
        coralCoins = score / 100;
    }

    public void LoadData(GameData data)
    {
        this.coralCoins += data.coralCoints;
    }

    public void SaveData(GameData data)
    {
        data.coralCoints += this.coralCoins;
    }
}
