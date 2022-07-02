using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnClic : MonoBehaviour
{
    private SelectedTool st;
    public Sprite[] sprites;

    // Start is called before the first frame update
    void Start()
    {
        st = GameObject.Find("tools").GetComponent<SelectedTool>();

        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, sprites.Length)];
    }

    private void OnMouseDown()
    {
        if (st.isCorrectTool(3)) {
            Destroy(this.gameObject);
        } else {
            // play sound
        }
    }
}
