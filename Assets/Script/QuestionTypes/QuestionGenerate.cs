using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerate : MonoBehaviour
{
    private static SpawnerFishesQ spawn;
    public static string correctA;
    public GameObject QuestionImg;
    private int A,B,C,D,randomValue;

    private string AF,BF,CF,DF;

    private int[] swapAns = new int[4];

    public System.Random random = new System.Random();

    // Start is called before the first frame update
    void Start()
    {
        spawn = FindObjectOfType<SpawnerFishesQ>();
        spawn.DoSpawn();
        GenerateAnswers();
        // El panel esta oculto de las preguntas
        // Mostrar los peces
        QuestionImg.SetActive(true);
        QuestionDisplay.newA = AF;
        QuestionDisplay.newB = BF;
        QuestionDisplay.newC = CF;
        QuestionDisplay.newD = DF;
        // Esperar n segundos

        // Mostrar panel de preguntas

        // Remover peces

        // Cuando se resuelva regresa a mostrar peces
        // spawn.spawnLFQ
        // Debug.Log(spawn.spawnGFQ);
        // Debug.Log(spawn.spawnPFQ);

        
    }

    void GenerateAnswers(){
        A =  Random.Range(spawn.spawnLFQ + 1, 8);
        B =  Random.Range(A + 1 , 10);
        C =  Random.Range(B + 1, 12);
        D =  Random.Range(D + 1, 14);
        swapAns = new int[4] { A, B, C, D };
        randomValue = swapAns[random.Next(0, swapAns.Length)];
        if(randomValue == A){
            A = spawn.spawnLFQ;
        }

        else if(randomValue == B){
            B = spawn.spawnLFQ;
        }

        else if(randomValue == C){
            C = spawn.spawnLFQ;
        }

        else if(randomValue == D){
            D = spawn.spawnLFQ;
        }
        AF = A.ToString();
        BF = B.ToString();
        CF = C.ToString();
        DF = D.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
