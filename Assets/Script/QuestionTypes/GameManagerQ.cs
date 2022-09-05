using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerQ : MonoBehaviour
{
    public GameObject panelQuestion;
    public GameObject panelRound;
    public Text timeRText;
    public Text timeQText;

    public float durationR, currentTimeR, durationQ, currentTimeQ;

    void Start()
    {
        panelRound.SetActive(true);
        currentTimeR = durationR;
        currentTimeQ = durationQ;
        StartCoroutine(TimeInRound());
    }

    IEnumerator TimeInRound()
    {
        while(currentTimeR >= 0){
            timeRText.text = currentTimeR.ToString();
            yield return new WaitForSeconds(1f);
            currentTimeR--;
        }
        openPanel();
    }

    IEnumerator TimeInQuestion()
    {
        while(currentTimeQ >= 0){
            timeQText.text = currentTimeQ.ToString();
            yield return new WaitForSeconds(1f);
            currentTimeQ--;
        }
    }
    

    void openPanel()
    {
        panelRound.SetActive(false);
        panelQuestion.SetActive(true);
        StartCoroutine(TimeInQuestion());
    }

}
