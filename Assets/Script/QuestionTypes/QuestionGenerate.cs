using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerate : MonoBehaviour
{
    private static SpawnerFishesQ spawn;
    public static string currentAnswer, correctAnswer;
    
    public GameObject QuestionImg,QuestionImg2,QuestionImg3;
    private int A,B,C,D,randomQuestion,randomAnswer,randomNumber;

    private string AF,BF,CF,DF;

    private int[] swapAns = new int[4];

    private List<int> listNumbers = new List<int>();

    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        spawn = FindObjectOfType<SpawnerFishesQ>();
        spawn.DoSpawn();
        QuestionsView();
    }

    public void RandomAnswers()
    {
        for (int i = 0; i < 4; i++)
        {
            do {
                randomNumber = random.Next(1, 5);
            } while (listNumbers.Contains(randomNumber));
            listNumbers.Add(randomNumber);
        }
    }


    public void GenerateAnswers(int spawnType)
    {
        RandomAnswers();
        A = listNumbers[0] + spawnType;
        B = listNumbers[1] + spawnType;
        C = listNumbers[2] + spawnType;
        D = listNumbers[3] + spawnType;
        swapAns = new int[4] { A, B, C, D };
        randomAnswer = swapAns[random.Next(0, swapAns.Length)];
        if(randomAnswer == A){
            A = spawnType;
        }

        else if(randomAnswer == B){
            B = spawnType;
        }

        else if(randomAnswer == C){
            C = spawnType;
        }

        else if(randomAnswer == D){
            D = spawnType;
        }
        AF = A.ToString();
        BF = B.ToString();
        CF = C.ToString();
        DF = D.ToString();
        correctAnswer = spawnType.ToString();
    }

    public void QuestionsView()
    {
        randomQuestion = Random.Range(1,3);
        if(randomQuestion == 1)
        {
            GenerateAnswers(spawn.spawnLFQ);
            QuestionDisplay.newQuestion = "Cuantas veces observaste esta especie:";
            QuestionImg.SetActive(true);
            QuestionDisplay.newA = AF;
            QuestionDisplay.newB = BF;
            QuestionDisplay.newC = CF;
            QuestionDisplay.newD = DF;
            CheckAnswers(correctAnswer);
        }

        if(randomQuestion == 2)
        {
            GenerateAnswers(spawn.spawnGFQ);
            QuestionDisplay.newQuestion = "Cuantas veces observaste esta especie:";
            QuestionImg2.SetActive(true);
            QuestionDisplay.newA = AF;
            QuestionDisplay.newB = BF;
            QuestionDisplay.newC = CF;
            QuestionDisplay.newD = DF;
            CheckAnswers(correctAnswer);
        }

        if(randomQuestion == 3)
        {
            GenerateAnswers(spawn.spawnPFQ);
            QuestionDisplay.newQuestion = "Cuantas veces observaste esta especie:";
            QuestionImg3.SetActive(true);
            QuestionDisplay.newA = AF;
            QuestionDisplay.newB = BF;
            QuestionDisplay.newC = CF;
            QuestionDisplay.newD = DF;
            CheckAnswers(correctAnswer);
        }
    }
    public void CheckAnswers(string Answer)
    {
        // Debug.Log(correctAnswer);
        // Debug.Log(answer);
        if (AF == Answer){
            currentAnswer = "A";
        }

        if (BF == Answer){
            currentAnswer = "B";
        }

        if (CF == Answer){
            currentAnswer = "C";
        }

        if (DF == Answer){
            currentAnswer = "D";
        }
        
    }

}
