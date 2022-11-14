using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


// This class has the job of initializing each tip that will have each level that exists in the canvas, 
// as we know each image represents a level so all these elements have different message, position and size in the canvas.

// Variables:

// tipToShow: This variable stores the message that you want to display in the tip, 
// for example: I want to keep the mouse pointer in the area of the first image to display the text "Level 1 - Defend the Reef".

// timeToWait: This variable stores the delay time that I want to exist to deploy and hide the tip, as we know when the pointer is in the 
// area the OnMouseHover method is triggered and when it is not in the area the OnMouseLoseFocus method is triggered, 
// if it does not have the delay it is triggered too fast and remember that these methods depend on others so we do not give time to 
// the other methods to be able to be triggered correctly.

// Methods:

// StartTimer() method

// The general idea of this coroutine is to display the stored message right at the position where the mouse pointer is located.

// Why use a Courotine

// A coroutine allows you to spread tasks across several frames. In Unity, a coroutine is a method that can pause execution and return control to 
// Unity but then continue where it left off on the following frame.
// In most situations, when you call a method, it runs to completion and then returns control to the calling method, plus any optional return values. 
// This means that any action that takes place within a method must happen within a single frame update.
// In situations where you would like to use a method call to contain a procedural animation or a sequence of events over time, you can use a coroutine.

// OnPointerEnter() method
// The idea of this method is to call the CoralTipManager variable that stores the position of the mouse pointer when it is on the image.

// OnPointerExit() method
// The idea of this method is to stop storing the message and call the CoralTipManager variable that stores when the mouse pointer is not in the image.


public class CoralTip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string tipToShow;
    private float timeToWait = 0.5f;
    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(StartTimer());
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        CoralTipManager.OnMouseLoseFocus();
    }

    private void ShowMessage()
    {
        CoralTipManager.OnMouseHover(tipToShow, Input.mousePosition);
    }

    private IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(timeToWait);
        ShowMessage();
    }

}
