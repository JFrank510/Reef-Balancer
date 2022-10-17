using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionGenerate : MonoBehaviour
{
    private static SpawnerFishesQ spawn;
    private static QuestionDisplay question;
    public static string currentAnswer, correctAnswer, correctAnswerText;
    public GameObject QuestionImg, QuestionImg2, QuestionImg3, QuestionImg4;
    public GameObject AnswerAImg, AnswerAImg2, AnswerAImg3, AnswerAImg4;
    public GameObject AnswerBImg, AnswerBImg2, AnswerBImg3, AnswerBImg4;
    public GameObject AnswerCImg, AnswerCImg2, AnswerCImg3, AnswerCImg4;
    public GameObject AnswerDImg, AnswerDImg2, AnswerDImg3, AnswerDImg4;
    private int A, B, C, D, randomQuestion, randomAnswer, randomNumber, higherValue, lessValue, randomArrayNumber;
    private string AF, BF, CF, DF;
    private string AI, BI, CI, DI;
    private int AIF, BIF, CIF, DIF;
    private int[] swapAns = new int[4];
    private List<int> listNumbers = new List<int>();
    private List<int> listArrayNumber = new List<int>();
    private string[] answersImage = new string[4];
    private System.Random random = new System.Random();


    // Start is called before the first frame update
    void Start()
    {
        QuestionsView();
    }

    void Awake()
    {
        spawn = FindObjectOfType<SpawnerFishesQ>();
    }

    private void ChangeFontSize()
    {
        question.answerA.GetComponent<Text>().fontSize = 10;
        question.answerB.GetComponent<Text>().fontSize = 10;
        question.answerC.GetComponent<Text>().fontSize = 10;
        question.answerD.GetComponent<Text>().fontSize = 10;
    }

    public void RandomAnswers()
    {
        for (int i = 0; i < 4; i++)
        {
            do
            {
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
        if (randomAnswer == A)
        {
            A = spawnType;
        }

        else if (randomAnswer == B)
        {
            B = spawnType;
        }

        else if (randomAnswer == C)
        {
            C = spawnType;
        }

        else if (randomAnswer == D)
        {
            D = spawnType;
        }
        AF = A.ToString();
        BF = B.ToString();
        CF = C.ToString();
        DF = D.ToString();
        correctAnswer = spawnType.ToString();
    }

    public void AnswersSort()
    {
        spawn.listNumbersSpawn.Sort();
        // foreach(int value in spawn.listNumbersSpawn)
        // {
        //     Debug.Log(value);
        // }
        higherValue = spawn.listNumbersSpawn[3];
        lessValue = spawn.listNumbersSpawn[0];
        Debug.Log(higherValue);
        // Debug.Log(lessValue);
    }


    public void GenerateAnswersImage()
    {
        AnswersSort();
        answersImage = new string[] { "LionFish", "GreenFish", "PinkFish", "BlueFish" };
        for (int i = 0; i < 4; i++)
        {
            do
            {
                randomArrayNumber = random.Next(0, 4);
            } while (listArrayNumber.Contains(randomArrayNumber));
            listArrayNumber.Add(randomArrayNumber);
        }
        AIF = listArrayNumber[0];
        BIF = listArrayNumber[1];
        CIF = listArrayNumber[2];
        DIF = listArrayNumber[3];

        AI = answersImage[AIF];
        BI = answersImage[BIF];
        CI = answersImage[CIF];
        DI = answersImage[DIF];

        if (higherValue == spawn.spawnLFQ)
        {
            correctAnswerText = "LionFish";
        }

        if (higherValue == spawn.spawnGFQ)
        {
            correctAnswerText = "GreenFish";
        }

        if (higherValue == spawn.spawnPFQ)
        {
            correctAnswerText = "PinkFish";
        }

        if (higherValue == spawn.spawnBFQ)
        {
            correctAnswerText = "BlueFish";
        }
    }

    public void DisplayImageButton()
    {
        if (AI == "LionFish")
        {
            AnswerAImg.SetActive(true);
        }
        if (AI == "GreenFish")
        {
            AnswerAImg2.SetActive(true);
        }

        if (AI == "PinkFish")
        {
            AnswerAImg3.SetActive(true);
        }

        if (AI == "BlueFish")
        {
            AnswerAImg4.SetActive(true);
        }

        if (BI == "LionFish")
        {
            AnswerBImg.SetActive(true);
        }

        if (BI == "GreenFish")
        {
            AnswerBImg2.SetActive(true);
        }

        if (BI == "PinkFish")
        {
            AnswerBImg3.SetActive(true);
        }

        if (BI == "BlueFish")
        {
            AnswerBImg4.SetActive(true);
        }

        if (CI == "LionFish")
        {
            AnswerCImg.SetActive(true);
        }

        if (CI == "GreenFish")
        {
            AnswerCImg2.SetActive(true);
        }

        if (CI == "PinkFish")
        {
            AnswerCImg3.SetActive(true);
        }

        if (CI == "BlueFish")
        {
            AnswerCImg4.SetActive(true);
        }

        if (DI == "LionFish")
        {
            AnswerDImg.SetActive(true);
        }

        if (DI == "GreenFish")
        {
            AnswerDImg2.SetActive(true);
        }

        if (DI == "PinkFish")
        {
            AnswerDImg3.SetActive(true);
        }

        if (DI == "BlueFish")
        {
            AnswerDImg4.SetActive(true);
        }
    }

    public void CheckAnswersText()
    {
        if (AI == correctAnswerText)
        {
            currentAnswer = "A";
        }

        if (BI == correctAnswerText)
        {
            currentAnswer = "B";
        }

        if (CI == correctAnswerText)
        {
            currentAnswer = "C";
        }

        if (DI == correctAnswerText)
        {
            currentAnswer = "D";
        }

    }
    public void CheckAnswers(string Answer)
    {
        // Debug.Log(correctAnswer);
        // Debug.Log(answer);
        if (AF == Answer)
        {
            currentAnswer = "A";
        }

        if (BF == Answer)
        {
            currentAnswer = "B";
        }

        if (CF == Answer)
        {
            currentAnswer = "C";
        }

        if (DF == Answer)
        {
            currentAnswer = "D";
        }

    }

    public void QuestionsView()
    {
        // randomQuestion = 1;
        randomQuestion = Random.Range(1, 5);
        if (randomQuestion == 1)
        {
            GenerateAnswersText(spawn.spawnLFQ);
            QuestionDisplay.newQuestion = "Cuantas veces observaste esta especie:";
            QuestionImg.SetActive(true);
            QuestionDisplay.newA = AF;
            QuestionDisplay.newB = BF;
            QuestionDisplay.newC = CF;
            QuestionDisplay.newD = DF;
            CheckAnswers(correctAnswer);
        }

        if (randomQuestion == 2)
        {
            GenerateAnswersText(spawn.spawnGFQ);
            QuestionDisplay.newQuestion = "Cuantas veces observaste esta especie:";
            QuestionImg2.SetActive(true);
            QuestionDisplay.newA = AF;
            QuestionDisplay.newB = BF;
            QuestionDisplay.newC = CF;
            QuestionDisplay.newD = DF;
            CheckAnswers(correctAnswer);
        }

        if (randomQuestion == 3)
        {
            GenerateAnswersText(spawn.spawnPFQ);
            QuestionDisplay.newQuestion = "Cuantas veces observaste esta especie:";
            QuestionImg3.SetActive(true);
            QuestionDisplay.newA = AF;
            QuestionDisplay.newB = BF;
            QuestionDisplay.newC = CF;
            QuestionDisplay.newD = DF;
            CheckAnswers(correctAnswer);
        }

        if (randomQuestion == 4)
        {
            GenerateAnswersText(spawn.spawnBFQ);
            QuestionDisplay.newQuestion = "Cuantas veces observaste esta especie:";
            QuestionImg4.SetActive(true);
            QuestionDisplay.newA = AF;
            QuestionDisplay.newB = BF;
            QuestionDisplay.newC = CF;
            QuestionDisplay.newD = DF;
            CheckAnswers(correctAnswer);
        }

        if (randomQuestion == 5)
        {
            GenerateAnswersImage();
            DisplayImageButton();
            ChangeFontSize();
            QuestionDisplay.newQuestion = "Cual especie observaste mas?:";
            QuestionDisplay.newA = AI;
            QuestionDisplay.newB = BI;
            QuestionDisplay.newC = CI;
            QuestionDisplay.newD = DI;
            CheckAnswersText();
        }
    }

}
