using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDisplay : MonoBehaviour
{
    public GameObject answerA,answerB,answerC,answerD;
    public static string newA,newB,newC,newD;



    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(PushTextOnScreen());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator PushTextOnScreen(){
        yield return new WaitForSeconds(0.25f);
        answerA.GetComponent<Text>().text = newA;
        answerB.GetComponent<Text>().text = newB;
        answerC.GetComponent<Text>().text = newC;
        answerD.GetComponent<Text>().text = newD;
    }
}
