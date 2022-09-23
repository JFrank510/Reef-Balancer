using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerate : MonoBehaviour
{
    private static SpawnerFishesQ spawn;
    public static string currentAnswer, correctAnswer;
    public GameObject QuestionImg,QuestionImg2,QuestionImg3,QuestionImg4,panelQuestionT,panelQuestionI;
    public Sprite AnswerAImg,AnswerBImg,AnswerCImg,AnswerDImg;
    private int A,B,C,D,randomQuestion,randomAnswer,randomNumber,higherValue,lessValue;

    private string AF,BF,CF,DF;

    private int[] swapAns = new int[4];

    private Sprite[] answersImage = new Sprite[4];

    private List<int> listNumbers = new List<int>();
    private System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        spawn = FindObjectOfType<SpawnerFishesQ>();
        spawn.DoSpawn();
        QuestionsView();
        AnswersSort();
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


    public void GenerateAnswersText(int spawnType)
    {
        RandomAnswers();
        A = listNumbers[0] + spawnType;
        B = listNumbers[1] + spawnType;
        C = listNumbers[2] + spawnType;
        D = listNumbers[3] + spawnType;
        swapAns = new int[] { A, B, C, D };
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

    public void GenerateAnswersImage(){
       answersImage = new Sprite[] {AnswerAImg,AnswerBImg,AnswerCImg,AnswerDImg};
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

    public void AnswersSort()
    {
        spawn.listNumbersSpawn.Sort();
        // foreach(int value in spawn.listNumbersSpawn)
        // {
        //     Debug.Log(value);
        // }
        higherValue = spawn.listNumbersSpawn[2];
        lessValue = spawn.listNumbersSpawn[0];
        Debug.Log(higherValue);
        Debug.Log(lessValue);
    }


    public void QuestionsView()
    {
        if(QuestionDisplay.randomQuestion == 0)
        {
            panelQuestionT.SetActive(true);
            // randomQuestion = 4;
            randomQuestion = Random.Range(1,4);
            if(randomQuestion == 1)
            {
                GenerateAnswersText(spawn.spawnLFQ);
                QuestionDisplay.newQuestion = "Cuantas veces observaste esta especie:";
                QuestionImg2.SetActive(false);
                QuestionImg3.SetActive(false);
                QuestionImg4.SetActive(false);
                QuestionDisplay.newA = AF;
                QuestionDisplay.newB = BF;
                QuestionDisplay.newC = CF;
                QuestionDisplay.newD = DF;
                CheckAnswers(correctAnswer);
            }

            if(randomQuestion == 2)
            {
                GenerateAnswersText(spawn.spawnGFQ);
                QuestionDisplay.newQuestion = "Cuantas veces observaste esta especie:";
                QuestionImg.SetActive(false);
                QuestionImg3.SetActive(false);
                QuestionImg4.SetActive(false);
                QuestionDisplay.newA = AF;
                QuestionDisplay.newB = BF;
                QuestionDisplay.newC = CF;
                QuestionDisplay.newD = DF;
                CheckAnswers(correctAnswer);
            }

            if(randomQuestion == 3)
            {
                GenerateAnswersText(spawn.spawnPFQ);
                QuestionDisplay.newQuestion = "Cuantas veces observaste esta especie:";
                QuestionImg.SetActive(false);
                QuestionImg2.SetActive(false);
                QuestionImg4.SetActive(false);
                QuestionDisplay.newA = AF;
                QuestionDisplay.newB = BF;
                QuestionDisplay.newC = CF;
                QuestionDisplay.newD = DF;
                CheckAnswers(correctAnswer);
            }

            if(randomQuestion == 4)
            {
                GenerateAnswersText(spawn.spawnBFQ);
                QuestionDisplay.newQuestion = "Cuantas veces observaste esta especie:";
                QuestionImg.SetActive(false);
                QuestionImg2.SetActive(false);
                QuestionImg3.SetActive(false);
                QuestionDisplay.newA = AF;
                QuestionDisplay.newB = BF;
                QuestionDisplay.newC = CF;
                QuestionDisplay.newD = DF;
                CheckAnswers(correctAnswer);
            }
        }

        if(QuestionDisplay.randomQuestion == 1)
        {
            panelQuestionI.SetActive(true);
            randomQuestion = Random.Range(1,4);
            if(randomQuestion == 1)
            {
                QuestionDisplay.newQuestion = "Cual especie observaste mas?:";
                QuestionDisplay.newIA = AnswerAImg;
                QuestionDisplay.newIB = AnswerBImg;
                QuestionDisplay.newIC = AnswerCImg;
                QuestionDisplay.newID = AnswerDImg;
            }
            

        }
    }

}
