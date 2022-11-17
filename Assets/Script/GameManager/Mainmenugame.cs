using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Mainmenugame : MonoBehaviour, IDataPersistence
{
    public Text uiCoins;
    public int coralCoins;

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadSceneAsync(sceneName);
    }

    public void LoadData(GameData data)
    {
        this.coralCoins += data.coralCoints;
    }

    public void SaveData(GameData data)
    {
        data.coralCoints += this.coralCoins;
    }


    void Update()
    {
        uiCoins.text = (coralCoins.ToString());
    }

}
