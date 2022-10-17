using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDisplay : MonoBehaviour
{
    public GameObject screenQuestion, answerA, answerB, answerC, answerD;
    public static string newQuestion, newA, newB, newC, newD;

    void Start()
    {
            StartCoroutine(PushTextOnScreen());
    }

    IEnumerator PushTextOnScreen()
    {
        yield return new WaitForSeconds(0.25f);
        screenQuestion.GetComponent<Text>().text = newQuestion;
        answerA.GetComponent<Text>().text = newA;
        answerB.GetComponent<Text>().text = newB;
        answerC.GetComponent<Text>().text = newC;
        answerD.GetComponent<Text>().text = newD;
    }
}
