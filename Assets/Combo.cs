using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Combo : MonoBehaviour
{
    public float duration = 0.0f;
    public int combo = 0;
    public TMP_Text comboCounter;

    void Start() {
        comboCounter = GameObject.Find("ComboCounter").GetComponent<TMP_Text>();
        comboCounter.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (duration > 0.0f) {
            duration -= Time.deltaTime;
        }

        if (duration <= 0.0f) {
            duration = 0.0f;
            combo = 0;
        }

        if (combo > 1) {
            comboCounter.SetText("x" + combo.ToString());
            comboCounter.gameObject.SetActive(true);
        } else {
            comboCounter.gameObject.SetActive(false);
        }
    }

    public int GetCombo()
    {
        duration = 3.0f;
        combo++;

        return combo;
    }

    public void ResetCombo()
    {
        duration = 0.0f;
        combo = 0;
    }
}
