using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static int score;
    public Text scoreTxt;
    public Text scoreGameover;

    public GameObject panel;

    private static Combo cmb;

    void Start()
    {
        panel.SetActive(false);
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
    }

}
