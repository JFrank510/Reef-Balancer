using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainPanel : MonoBehaviour
{
    [Header("Opciones")]
    public Slider volumen;
    public Toggle mute;

    [Header("Panels")]
    public GameObject mainPanel;
    public GameObject optionsPanel;

    public void openPanel(GameObject panel){
        mainPanel.SetActive(false);
        optionsPanel.SetActive(false);
        panel.SetActive(true);
    }

    public void Jugar(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 );
    }


}
