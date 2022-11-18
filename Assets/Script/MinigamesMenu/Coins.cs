using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour, IDataPersistence
{
    public Text uiCoins;
    public int coralCoins;

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
