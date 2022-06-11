using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenugame : MonoBehaviour
{
    public void Menu(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }

    public void goBack(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1 );
    }

}
