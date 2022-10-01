using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonQ : MonoBehaviour
{
    public GameObject answerABlue, answerARed, answerAGreen, answerIABlue, answerIARed, answerIAGreen;
    public GameObject answerBBlue, answerBRed, answerBGreen, answerIBBlue, answerIBRed, answerIBGreen;
    public GameObject answerCBlue, answerCRed, answerCGreen, answerICBlue, answerICRed, answerICGreen;
    public GameObject answerDBlue, answerDRed, answerDGreen, answerIDBlue, answerIDRed, answerIDGreen;
    public GameObject answerA, answerB, answerC, answerD;
    public GameObject answerIA, answerIB, answerIC, answerID;

    public void AnswerA()
    {
        if (QuestionGenerate.currentAnswer == "A")
        {
            answerAGreen.SetActive(true);
            answerABlue.SetActive(false);
            answerIAGreen.SetActive(true);
            answerIABlue.SetActive(false);
        }

        else
        {
            answerARed.SetActive(true);
            answerABlue.SetActive(false);
            answerIARed.SetActive(true);
            answerIABlue.SetActive(false);
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
        answerIA.GetComponent<Button>().enabled = false;
        answerIB.GetComponent<Button>().enabled = false;
        answerIC.GetComponent<Button>().enabled = false;
        answerID.GetComponent<Button>().enabled = false;
    }

    public void AnswerB()
    {
        if (QuestionGenerate.currentAnswer == "B")
        {
            answerBGreen.SetActive(true);
            answerBBlue.SetActive(false);
            answerIBGreen.SetActive(true);
            answerIBBlue.SetActive(false);
        }

        else
        {
            answerBRed.SetActive(true);
            answerBBlue.SetActive(false);
            answerIBRed.SetActive(true);
            answerIBBlue.SetActive(false);
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
        answerIA.GetComponent<Button>().enabled = false;
        answerIB.GetComponent<Button>().enabled = false;
        answerIC.GetComponent<Button>().enabled = false;
        answerID.GetComponent<Button>().enabled = false;
    }

    public void AnswerC()
    {
        if (QuestionGenerate.currentAnswer == "C")
        {
            answerCGreen.SetActive(true);
            answerCBlue.SetActive(false);
            answerICGreen.SetActive(true);
            answerICBlue.SetActive(false);
        }

        else
        {
            answerCRed.SetActive(true);
            answerCBlue.SetActive(false);
            answerICRed.SetActive(true);
            answerICBlue.SetActive(false);
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
        answerIA.GetComponent<Button>().enabled = false;
        answerIB.GetComponent<Button>().enabled = false;
        answerIC.GetComponent<Button>().enabled = false;
        answerID.GetComponent<Button>().enabled = false;
    }

    public void AnswerD()
    {
        if (QuestionGenerate.currentAnswer == "D")
        {
            answerDGreen.SetActive(true);
            answerDBlue.SetActive(false);
            answerIDGreen.SetActive(true);
            answerIDBlue.SetActive(false);
        }

        else
        {
            answerDRed.SetActive(true);
            answerDBlue.SetActive(false);
            answerIDRed.SetActive(true);
            answerIDBlue.SetActive(false);
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
        answerIA.GetComponent<Button>().enabled = false;
        answerIB.GetComponent<Button>().enabled = false;
        answerIC.GetComponent<Button>().enabled = false;
        answerID.GetComponent<Button>().enabled = false;
    }

}
