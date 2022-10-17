using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerQ : MonoBehaviour
{
    public GameObject panelQuestion;
    public GameObject panelRound,spawnHUD;
    // ,spawn,spawn2,spawn3;
    private static QuestionGenerate question;
    public Text timeRText;
    // public Text timeQText;
    private float currentTimeR;
    public GameObject[] Fishes;
    // public float durationQ,currentTimeQ;

    public void Start()
    {
        panelRound.SetActive(true);
        currentTimeR = 10;
        // currentTimeQ = durationQ;
        StartCoroutine(TimeInRound());
    }

    IEnumerator TimeInRound()
    {
        while (currentTimeR >= 0)
        {
            timeRText.text = currentTimeR.ToString();
            yield return new WaitForSeconds(1f);
            currentTimeR--;
        }
        openPanel();
    }
    
    void DesactivateFishes()
    {
        Fishes = GameObject.FindGameObjectsWithTag("Fish");
        foreach (GameObject Fish in Fishes)
        {
            // Fish.SetActive(false);
            Destroy(Fish);
        }
    }

    // IEnumerator TimeInQuestion()
    // {
    //     while (currentTimeQ >= 0)
    //     {
    //         timeQText.text = currentTimeQ.ToString();
    //         yield return new WaitForSeconds(1f);
    //         currentTimeQ--;
    //     }
    // }


    void openPanel()
    {
        panelRound.SetActive(false);
        panelQuestion.SetActive(true);
        spawnHUD.SetActive(false);
        DesactivateFishes();
        // StartCoroutine(TimeInQuestion());
    }

}
