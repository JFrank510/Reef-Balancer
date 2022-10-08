using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trash : MonoBehaviour
{
    public float speedY = 5.0f;
    public bool isDouble = false;
    private VerticalPlayer vp;
    private Runner rn;
    private Rigidbody2D rb;
    public Sprite[] sprites;
    public float[] scales;
    public float[] radius;
    public bool rotate = false;
    private UnityEngine.Rendering.Universal.Light2D lt;

    // Start is called before the first frame update
    void Start()
    {
        vp = GameObject.Find("Player").GetComponent<VerticalPlayer>();
        rn = GameObject.Find("Main Camera").GetComponent<Runner>();
        lt = GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speedY, 0.0f);   
        rb.isKinematic = false;
        int random = 0;
        
        if (this.transform.position.y == -2.25f) { 
            // Only Coral Sprites
            this.name = "Coral";
            random = Random.Range(sprites.Length - 2, sprites.Length); 
        } else { 
            // Non Coral Sprites
            rotate = true;
            random = Random.Range(0, sprites.Length - 2);
        }        

        // select sprite
        GetComponent<SpriteRenderer>().sprite = sprites[random];

        // select box and scale
        GetComponent<BoxCollider2D>().size = new Vector2(radius[random], radius[random]);
        this.gameObject.transform.localScale = new Vector3(scales[random], scales[random], scales[random]);
    }

    void Update()
    {
        // Trash should rotate
        if (rotate) {
            this.transform.Rotate(0, 0, 60 * Time.deltaTime);
        }

        // update light intensity if is night.
        if (this.name == "Coral") {
            if (rn.isNigth()) {
                lt.intensity = 0.6f;
            } else {
                lt.intensity = 0.0f;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // If collide with player
        if (other.name == "Player") {
            // if player is vulnerable
            if (vp.isVulnerable) {
                // reduce life
                vp.lives--;

                // make 3s invulnerable
                vp.Invulnerable();

                Destroy(this.gameObject);
            }
        } else if (other.name == "Trash") {
            Destroy(this.gameObject);
            rn.AddPoints(100);
        }
    }
}
