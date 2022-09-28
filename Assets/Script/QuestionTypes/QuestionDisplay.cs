using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDisplay : MonoBehaviour
{
    public GameObject screenQuestion,answerA,answerB,answerC,answerD;
    public GameObject screenQuestionI,answerIA,answerIB,answerIC,answerID;
    public static string newQuestion,newA,newB,newC,newD,questionType;
    public static string newIA,newIB,newIC,newID;
    private string[] swapQuestion = new string[2];
    private System.Random random = new System.Random();
    public static int randomQuestion;

    // Start is called before the first frame update
    void Start()
    {
        // StartCoroutine(PushTextOnScreen());
        ChooseQuestionType();
    }


    IEnumerator PushTextOnScreen(){
        yield return new WaitForSeconds(0.25f);
        screenQuestion.GetComponent<Text>().text = newQuestion;
        answerA.GetComponent<Text>().text = newA;
        answerB.GetComponent<Text>().text = newB;
        answerC.GetComponent<Text>().text = newC;
        answerD.GetComponent<Text>().text = newD;
    }

    IEnumerator PushImagenOnScreen(){
        yield return new WaitForSeconds(0.25f);
        screenQuestionI.GetComponent<Text>().text = newQuestion;
        answerIA.GetComponent<Text>().text = newIA;
        answerIB.GetComponent<Text>().text = newIB;
        answerIC.GetComponent<Text>().text = newIC;
        answerID.GetComponent<Text>().text = newID;
    }
    public void ChooseQuestionType(){
        swapQuestion = new string[] {"Text","Image"};
        // randomQuestion = random.Next(swapQuestion.Length);
        randomQuestion = 1;
        if(randomQuestion == 0)
            StartCoroutine(PushTextOnScreen());
        if(randomQuestion == 1)
            StartCoroutine(PushImagenOnScreen());
    }
}
