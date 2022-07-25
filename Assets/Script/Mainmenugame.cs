using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenugame : MonoBehaviour
{
    public void Level1(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

    public void Level2(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2 );
    }

    public void goBack(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 );
    }

}
