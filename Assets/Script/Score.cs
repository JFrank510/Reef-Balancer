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

    private static Combo cmb;

    void Start()
    {
        panel.SetActive(false);
        capturefish = 0;
        score = 0;
        Time.timeScale = 1f;
        cmb = this.transform.GetComponent<Combo>();
    }
    
    public static void updateScore(int points)
    {
        // Get the current combo
        int combo = cmb.GetCombo();

        // Update the score
        score += combo * points;
    }

    public static void ResetCombo()
    {
        cmb.ResetCombo();
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
