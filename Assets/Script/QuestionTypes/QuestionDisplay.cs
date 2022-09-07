using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionDisplay : MonoBehaviour
{
    public GameObject AnswerA;
    public GameObject AnswerB;
    public GameObject AnswerC;
    public GameObject AnswerD;
    public static string newA;
    public static string newB;
    public static string newC;
    public static string newD;    

    // Start is called before the first frame update
    void Start()
    {
        // AnswerA.GetComponent<Text>().text = newA;
        // AnswerB.GetComponent<Text>().text = newB;
        // AnswerC.GetComponent<Text>().text = newC;
        // AnswerD.GetComponent<Text>().text = newD;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
