using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectedTool : MonoBehaviour
{
    public int selectedTool = 1;
    
    public bool isCorrectTool(int required)
    {
        return required == selectedTool;
    }

    public void setTool(int tool)
    {
        this.selectedTool = tool;
    }
}
