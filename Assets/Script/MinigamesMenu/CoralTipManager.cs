using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// This class is in charge of generating all the tips (we decided to call them this way because it is a message that 
// comes out of an image object inside the canvas) that will be shown on the screen, this tip is composed of a text and a background image.

// Variables:

// tipText: This variable stores a text object (here it doesn't really matter what kind of text object is used, 
// we decided to use the Mesh library but it can be a legacy text, it's just pure aesthetics).

// tipWindow: This variable will focus on saving both the size (vertical and horizontal) and the position in the canvas plane of the background of each tip.

// OnMouseHover: This variable stores the action of detecting that the mouse pointer is in the image area on the canvas.

// OnMouseLoseFocus: This variable stores the action of detecting that the mouse pointer is not in the image area on the canvas.

// Methods:

// Start() method

// The general idea of this method is to start the hide tip function.

// Why the Start() method

// Start is called in the framework when a script is enabled just before any of the Update methods are called for the first time.
// Like the Awake function, Start is called exactly once during the lifetime of the script. However, Awake is called when the script object is initialized, regardless 
// of whether scripting is enabled or not. Start may not be called in the same frame as Wake if the script is not enabled at initialization time.

// OnEnable() Method

// The idea of the OnEnable method is to detect the coordinates where the pointer is located whenever the object is active on the canvas.

// OnDisable() method

// The idea of the OnDisable method is to remove the coordinates where the pointer is located whenever the object is not active on the canvas.

// Why OnEnable() and OnDisable()

// As we know the Start method is only executed once per frame, this means that if we pass it a control variable it is only updated once and this is a problem because 
// it only saves the first position of the mouse and it is maintained so if the mouse is moved to another position the tip will always be displayed 
// in the same place, Unity has several initialization methods, for convenience use OnEnable and OnDisable as these are initialized 
// first and also they can be triggered as many times as needed so this allows us that the tip can be seen by the whole area of the image.

// ShowTip() method
// The idea of this method is to display the elements that make up a tip (Background, Text, Position of the mouse), 
// this is to give it dynamism and the tip goes all over the image area.

// HideTip() method
// The main idea is to hide the tip when the mouse is not in the image area.


public class CoralTipManager : MonoBehaviour
{
    public TextMeshProUGUI tipText;
    public RectTransform tipWindow;
    public static Action<string, Vector2> OnMouseHover;
    public static Action OnMouseLoseFocus;

    private void OnEnable()
    {
        OnMouseHover += ShowTip;
        OnMouseLoseFocus += HideTip;
    }

    private void OnDisable()
    {
        OnMouseHover -= ShowTip;
        OnMouseLoseFocus -= HideTip;
    }

    void Start()
    {
        HideTip();
    }

    private void ShowTip(string tip, Vector2 mousePos)
    {
        tipText.text = tip;
        tipWindow.sizeDelta = new Vector2(tipText.preferredWidth > 200 ? 200 : tipText.preferredWidth, tipText.preferredHeight);
        tipWindow.gameObject.SetActive(true);
        tipWindow.transform.position = new Vector2(mousePos.x, mousePos.y);
    }

    private void HideTip()
    {
        tipText.text = default;
        tipWindow.gameObject.SetActive(false);
    }
}
