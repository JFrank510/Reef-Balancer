using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerButtonQ : MonoBehaviour
{
    public GameObject answerABlue,answerARed,answerAGreen;
    public GameObject answerBBlue,answerBRed,answerBGreen;
    public GameObject answerCBlue,answerCRed,answerCGreen;
    public GameObject answerDBlue,answerDRed,answerDGreen;
    public GameObject answerA,answerB,answerC,answerD;

    public void AnswerA()
    {
        if(QuestionGenerate.currentAnswer == "A"){
            answerAGreen.SetActive(true);
            answerABlue.SetActive(false);
        }

        else{
            answerARed.SetActive(true);
            answerABlue.SetActive(false);
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
    }

    public void AnswerB(){
        if(QuestionGenerate.currentAnswer == "B"){
            answerBGreen.SetActive(true);
            answerBBlue.SetActive(false);
        }

        else{
            answerBRed.SetActive(true);
            answerBBlue.SetActive(false);
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
    }

        public void AnswerC(){
        if(QuestionGenerate.currentAnswer == "C"){
            answerCGreen.SetActive(true);
            answerCBlue.SetActive(false);
        }

        else{
            answerCRed.SetActive(true);
            answerCBlue.SetActive(false);
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
    }

        public void AnswerD(){
        if(QuestionGenerate.currentAnswer == "D"){
            answerDGreen.SetActive(true);
            answerDBlue.SetActive(false);
        }

        else{
            answerDRed.SetActive(true);
            answerDBlue.SetActive(false);
        }
        answerA.GetComponent<Button>().enabled = false;
        answerB.GetComponent<Button>().enabled = false;
        answerC.GetComponent<Button>().enabled = false;
        answerD.GetComponent<Button>().enabled = false;
    }

}
