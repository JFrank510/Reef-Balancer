using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowLight : MonoBehaviour
{
    public  SelectedTool st;
    public UnityEngine.Rendering.Universal.Light2D lt;
    public float batteryLevel = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        st = GameObject.Find("tools").GetComponent<SelectedTool>();
        lt = this.transform.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (st.isCorrectTool(2) && batteryLevel >= 100.0f) {
            lt.intensity = 0.4f;
        } else if (batteryLevel <= 100.0f) {
            batteryLevel += Time.deltaTime * 12.0f;
            Debug.Log("Battery Level: " + batteryLevel);
        }

        Vector3 mousePos = Input.mousePosition;

        
        this.gameObject.transform.localPosition = Camera.main.ScreenToWorldPoint(mousePos);;
    }
}
