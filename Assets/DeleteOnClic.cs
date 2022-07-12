using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteOnClic : MonoBehaviour
{
    private SelectedTool st;

    public Sprite[] sprites;
    public float[] scales;
    public float[] radius;

    // Start is called before the first frame update
    void Start()
    {
        st = GameObject.Find("tools").GetComponent<SelectedTool>();

        int random = Random.Range(0, sprites.Length);

        GetComponent<SpriteRenderer>().sprite = sprites[random];
        GetComponent<CircleCollider2D>().radius = radius[random];

        this.gameObject.transform.localScale = new Vector3(scales[random], scales[random], scales[random]);
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
