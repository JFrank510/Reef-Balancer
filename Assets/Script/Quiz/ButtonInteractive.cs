using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonInteractive : MonoBehaviour
{
    private int value;
    public GameObject btn;
    public TMP_Text text;

    public void Start()
    {
        SetColor(Color.white);
    }
    
    public void setText(string newContent)
    {
        text.SetText(newContent);
    }

    public void setValue(int newValue)
    {
        value = newValue;
        btn.GetComponent<Button>().interactable = true;
        SetColor(Color.white);
    }

    public bool isCorrect(int expected)
    {
        return value == expected;
    }

    public void Disable()
    {
        btn.GetComponent<Button>().interactable = false;
    }

    public void setCorrect()
    {
        SetColor(Color.green);
    }

    public void setIncorrect()
    {
        SetColor(Color.red);
    }

    void SetColor(Color c) {
        ColorBlock cb =  btn.GetComponent<Button>().colors;
        cb.disabledColor = c;
        btn.GetComponent<Button>().colors = cb;
    }
}
