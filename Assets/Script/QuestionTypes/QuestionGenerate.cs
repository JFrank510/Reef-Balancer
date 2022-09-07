using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionGenerate : MonoBehaviour
{
    private static SpawnerFishesQ spawn;
    public static string correctA;
    public GameObject QuestionImg;
    private int A;
    private int B;
    private int C;
    private int D;

    // Start is called before the first frame update
    void Start()
    {
        GenerateAnswer();
        spawn = FindObjectOfType<SpawnerFishesQ>();
        // El panel esta oculto de las preguntas
        // Mostrar los peces
        spawn.DoSpawn();
        QuestionImg.SetActive(true);
        QuestionDisplay.newA = "XD";
        QuestionDisplay.newB = "YEAH";
        QuestionDisplay.newC = "SIIIUUU";
        QuestionDisplay.newD = "OH NO";
        Debug.Log(A);

        // Esperar n segundos

        // Mostrar panel de preguntas

        // Remover peces

        // Cuando se resuelva regresa a mostrar peces
        // spawn.spawnLFQ
        // Debug.Log(spawn.spawnGFQ);
        // Debug.Log(spawn.spawnPFQ);

        
    }

    void GenerateAnswer(){
        A =  Random.Range(1, 8);
        B =  Random.Range(1, 8);
        C =  Random.Range(1, 8);
        D =  Random.Range(1, 8);
        A.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
