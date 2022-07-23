using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score;
    public static int capturefish;
    public Text scoreTxt;
    public InitializeMock max;
    public Text scoreGameover;
    public Text scoreWin;

    public GameObject panel;

    void Start()
    {
        panel.SetActive(false);
        capturefish = 0;
        score = 0;
        Time.timeScale = 1f;
    }
    
    public static void updateScore()
    {
        score++;
        capturefish++;
    }

    void LateUpdate()
    {
        scoreTxt.text = "Score: "+score;
        scoreGameover.text = score+" POINTS";
        scoreWin.text = score+" POINTS";

        if(capturefish == max.maximum)
        {
            OpenPanel();
        }
    }

    void OpenPanel()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

}
