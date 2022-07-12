using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeOver : MonoBehaviour
{
    public GameObject panel;
    public Text timeText;
    public float duration, currentTime;

    // Start is called before the first frame update
    void Start()
    {
        panel.SetActive(false);
        currentTime = duration;
        timeText.text = currentTime.ToString();
        StartCoroutine(TimeIEn());
        
    }

    IEnumerator TimeIEn(){
        while(currentTime >= 0){
            timeText.text = currentTime.ToString();
            yield return new WaitForSeconds(1f);
            currentTime--;

        }
        OpenPanel();
    }

    void OpenPanel()
    {
        timeText.text="";
        panel.SetActive(true);

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
