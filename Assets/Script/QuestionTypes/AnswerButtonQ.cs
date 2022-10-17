using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonQ : MonoBehaviour
{
    public GameObject spawn2, spawn3;
    public int round = 1;
    private static GameManagerQ game;
    public GameObject answerABlue, answerARed, answerAGreen;
    public GameObject answerBBlue, answerBRed, answerBGreen;
    public GameObject answerCBlue, answerCRed, answerCGreen;
    public GameObject answerDBlue, answerDRed, answerDGreen;
    public GameObject answerA, answerB, answerC, answerD;

    private void Awake()
    {
        game = FindObjectOfType<GameManagerQ>();
    }
    public void AnswerA()
    {
        if (QuestionGenerate.currentAnswer == "A")
        {
            answerAGreen.SetActive(true);
            answerABlue.SetActive(false);
            round++;
            StartCoroutine(NextQuestion());
            RoundRestart();
        }

        else
        {
            answerARed.SetActive(true);
            answerABlue.SetActive(false);
            StartCoroutine(NextQuestion());
            RoundRestart();
            round++;
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
    }

    public void AnswerB()
    {
        if (QuestionGenerate.currentAnswer == "B")
        {
            answerBGreen.SetActive(true);
            answerBBlue.SetActive(false);
            StartCoroutine(NextQuestion());
            RoundRestart();
            round++;
        }

        else
        {
            answerBRed.SetActive(true);
            answerBBlue.SetActive(false);
            StartCoroutine(NextQuestion());
            RoundRestart();
            round++;
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
    }

    public void AnswerC()
    {
        if (QuestionGenerate.currentAnswer == "C")
        {
            answerCGreen.SetActive(true);
            answerCBlue.SetActive(false);
            StartCoroutine(NextQuestion());
            RoundRestart();
            round++;
        }

        else
        {
            answerCRed.SetActive(true);
            answerCBlue.SetActive(false);
            StartCoroutine(NextQuestion());
            RoundRestart();
            round++;
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
    }

    public void AnswerD()
    {
        if (QuestionGenerate.currentAnswer == "D")
        {
            answerDGreen.SetActive(true);
            answerDBlue.SetActive(false);
            StartCoroutine(NextQuestion());
            RoundRestart();
            round++;
        }

        else
        {
            answerDRed.SetActive(true);
            answerDBlue.SetActive(false);
            StartCoroutine(NextQuestion());
            RoundRestart();
            round++;
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
    }

    IEnumerator NextQuestion()
    {
        yield return new WaitForSeconds(5);
        answerAGreen.SetActive(false);
        answerBGreen.SetActive(false);
        answerCGreen.SetActive(false);
        answerDGreen.SetActive(false);
        answerARed.SetActive(false);
        answerBRed.SetActive(false);
        answerCRed.SetActive(false);
        answerDRed.SetActive(false);
        answerABlue.SetActive(true);
        answerBBlue.SetActive(true);
        answerCBlue.SetActive(true);
        answerDBlue.SetActive(true);
        answerA.GetComponent<Button>().enabled = true;
        answerB.GetComponent<Button>().enabled = true;
        answerC.GetComponent<Button>().enabled = true;
        answerD.GetComponent<Button>().enabled = true;
    }

    // public void RoundRestart()
    // {
    //     IEnumerator Checkquestion()
    //     {
    //         spawn2.SetActive(true);
    //         game.panelQuestion.SetActive(false);
    //         // game.panelRound.SetActive(true);
    //         game.Start();
    //         // question.Start();
    //     }
    // }

    public void RoundRestart()
    {
        spawn2.SetActive(true);
        game.panelQuestion.SetActive(false);
        // game.panelRound.SetActive(true);
        game.Start();
        // question.Start();
    }

}
