using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OxygenBar : MonoBehaviour
{
    public float oxygen = 100;

    public GameObject panel;

    public Image oxygenBar;
    public GameObject OxygenTankPrefab;

    public float decreasePerMinute;
    public bool tankSpawned;
    
    void Start()
    {
        Time.timeScale = 1f;
        tankSpawned = false;
        panel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        oxygen = Mathf.Clamp(oxygen,0,100);
        oxygenBar.fillAmount = oxygen / 100;
        oxygen -= Time.deltaTime * decreasePerMinute / 60f;

        // Spawn an Oxygen Tank
        if (!tankSpawned && oxygen < 60.0f) {
            SpawnTank();
        }

        if(oxygen < 0.0f)
        {
            OpenPanel();
        }
    }

    public void UseTank()
    {
        // put oxygen to 100
        oxygen = 100;
        tankSpawned = false;
    }

    void SpawnTank()
    {
        tankSpawned = true;
        Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        GameObject a = Instantiate(OxygenTankPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x + 2, screenBounds.x - 2), screenBounds.y + 3);
    }

    void OpenPanel()
    {
        Time.timeScale = 0f;
        panel.SetActive(true);
    }

    public void restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    public void mainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MinigamesMenu");
    }
}
