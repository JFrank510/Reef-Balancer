using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnTool : MonoBehaviour
{
    private SelectedTool st;

    void Start()
    {
        st = GameObject.Find("tools").GetComponent<SelectedTool>();
    }

    // Update is called once per frame
    void Update()
    {
        if (st.isCorrectTool(1)) {
            this.gameObject.transform.localPosition = new Vector3(0.7f, -0.03f, 0);
        }

        if (st.isCorrectTool(2)) {
            this.gameObject.transform.localPosition = new Vector3(2.41f, -0.03f, 0);
        }

        if (st.isCorrectTool(3)) {
            this.gameObject.transform.localPosition = new Vector3(4.12f, -0.03f, 0);
        }
    }
}
