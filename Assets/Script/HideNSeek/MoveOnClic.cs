using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOnClic : MonoBehaviour
{
    private float startPosX;
    private float startPosY;

    public Sprite[] sprites;
    public float[] scales;
    public float[] radius;
    public bool hasBeenMoved = false;

    private SelectedTool st;

    void Start()
    {
        startPosX = transform.position.x;
        startPosY = transform.position.y;

        st = GameObject.Find("tools").GetComponent<SelectedTool>();

        int random = Random.Range(0, sprites.Length);

        GetComponent<SpriteRenderer>().sprite = sprites[random];
        GetComponent<CircleCollider2D>().radius = radius[random];

        this.gameObject.transform.localScale = new Vector3(scales[random],scales[random],scales[random]);
    }

    // Update is called once per frame
    void Update()
    {
        if (this.hasBeenMoved) {
            this.gameObject.transform.localPosition = new Vector3(startPosX + 1.5f, startPosY, -1);
        } else {
            this.gameObject.transform.localPosition = new Vector3(startPosX, startPosY, -1);
        }
    }

    private void OnMouseDown()
    {
        if (st.isCorrectTool(1)) {
            this.hasBeenMoved = !this.hasBeenMoved;
        } else {
            // play sound
        }
    }
}
