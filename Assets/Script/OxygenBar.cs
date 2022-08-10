using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBar : MonoBehaviour
{
    public float oxygen = 100;
    public Image oxygenBar;

    public float decreasePerMinute;
    

    // Update is called once per frame
    void Update()
    {
        oxygen = Mathf.Clamp(oxygen,0,100);
        oxygenBar.fillAmount = oxygen / 100;
        oxygen -= Time.deltaTime * decreasePerMinute / 60f;
        
    }
}
