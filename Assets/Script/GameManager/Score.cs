using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour, IDataPersistence
{
    public static int score;
    public Text scoreTxt;
    public Text scoreGameover;
    public Text scoreWin;
    public GameObject panel;
    private static Combo cmb;
    public int coralCoins;

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
        scoreTxt.text = "Score: " + score;
        scoreGameover.text = score + " POINTS";
        scoreWin.text = score + " POINTS";
    }

    public void scoreToCoins()
    {
        coralCoins = score / 100;
        Debug.Log(coralCoins);
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
