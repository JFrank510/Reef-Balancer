using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectTool : MonoBehaviour
{
    public int tool;

    private SelectedTool st;

    void Start()
    {
        st = this.transform.parent.GetComponent<SelectedTool>();
    }

    private void OnMouseDown()
    {
        st.setTool(tool);
    }
}
