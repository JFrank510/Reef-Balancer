using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionDisplay : MonoBehaviour
{
    private static SpawnerFishesQ spawn;
    public List<int> test = new List<int>();

    public GameObject imgF;

    public GameObject answerA;
    public GameObject answerB;
    public GameObject answerC;
    public GameObject answerD;
    public static string newQ;
    public static string newA;
    public static string newB;
    public static string newC;
    public static string newD;    

    // Start is called before the first frame update
    void Start()
    {
        spawn = FindObjectOfType<SpawnerFishesQ>();
        // El panel esta oculto de las preguntas

        // Mostrar los peces
        spawn.DoSpawn();

        // Esperar n segundos

        // Mostrar panel de preguntas

        // Remover peces

        // Cuando se resuelva regresa a mostrar peces
        // Debug.Log(spawn.spawnLFQ);
        // Debug.Log(spawn.spawnGFQ);
        // Debug.Log(spawn.spawnPFQ);

        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
