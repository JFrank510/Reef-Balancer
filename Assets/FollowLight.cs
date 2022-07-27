using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FollowLight : MonoBehaviour
{
    private TMP_Text battery;
    private SelectedTool st;
    private HideNSeek gameLogic;
    private UnityEngine.Rendering.Universal.Light2D lt;
    public float batteryLevel = 100.0f;
    // Start is called before the first frame update
    void Start()
    {
        gameLogic = this.transform.parent.GetComponent<HideNSeek>();
        battery = GameObject.Find("Text Battery").GetComponent<TMP_Text>();
        st = GameObject.Find("tools").GetComponent<SelectedTool>();
        lt = this.transform.GetComponent<UnityEngine.Rendering.Universal.Light2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // If light is on and we have battery, drain it
        if (lt.intensity > 0.2f && batteryLevel > 0.0f) {
            batteryLevel -= Time.deltaTime * 8.0f;
        } 
        
        // if light is off and battery is below 100%, recharge
        if (lt.intensity < 0.2f && batteryLevel < 100.0f)  {
            batteryLevel += Time.deltaTime * 12.0f;

            // Fix in case we have more than 100%
            if (batteryLevel > 100.0f) {
                batteryLevel = 100.0f;
            }
        }

        // when drained
        if (batteryLevel < 0.0f) {
            // turn off and put battery on 0%
            lt.intensity = 0.0f;
            batteryLevel = 0.0f;
        } 
        // if we have selected the lamp and the battery is > 99% we can turn on
        else if (st.isCorrectTool(2) && batteryLevel >= 99.0f && gameLogic.isNight) {
            lt.intensity = 0.6f;
        }

        battery.SetText(((int) batteryLevel).ToString() + '%');

        // The light must follow the mouse.
        Vector3 newMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        newMousePos.z = 1;
        this.gameObject.transform.localPosition = newMousePos;
    }
}
