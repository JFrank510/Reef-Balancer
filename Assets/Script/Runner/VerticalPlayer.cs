using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalPlayer : MonoBehaviour
{
    public int lives = 1;
    public bool isVulnerable;
    private float position = 0.0f;
    private float speedY = 0.0f;
    public float SPEED_Y;
    public float tick;

    private Vector2 screenBounds;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        isVulnerable = true;
        tick = 2.0f;
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0.0f, 0.0f);
        rb.isKinematic = false;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        Move();

        if (tick <= 0) {
            isVulnerable = true;
            tick = 2.0f;
            this.gameObject.transform.localScale = new Vector3(0.1861576f, 0.1861576f, 0.1861576f);
        } else if (tick > 0 && !isVulnerable) {
            tick -= Time.deltaTime;


            if (this.gameObject.transform.localScale == Vector3.zero) {
                this.gameObject.transform.localScale = new Vector3(0.1861576f, 0.1861576f, 0.1861576f);
            } else {
                this.gameObject.transform.localScale = Vector3.zero;
            }
        }
    }

    void Move()
    {
        Up();
        Down();

        // Check if we need to move or block movement
        if (speedY > 0.0f && this.transform.position.y <= position || speedY < 0.0f && this.transform.position.y >= position) {
            rb.velocity = new Vector2(0.0f, speedY);
        } else {
            speedY = 0.0f;
            rb.velocity = new Vector2(0.0f, speedY);
        }

        // rotate the player to follow a direction
        if (speedY > 0.0f) {
            this.transform.rotation = Quaternion.Euler(Vector3.forward * 15);
        } else if (speedY < 0.0f) {
            this.transform.rotation = Quaternion.Euler(Vector3.forward * -15);
        } else {
            this.transform.rotation = Quaternion.Euler(Vector3.forward * 0);
        }
    }

    void Up()
    {
        // Go to up
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) {
            switch (position) {
                case -2.25f:
                    position = 0.0f;
                    break;
                case 0.0f:
                    position = 2.25f;
                    break;
            }

            speedY = SPEED_Y;
        }
    }

    void Down()
    {
        // Go to Down
        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) {
            switch (position) {
                case 2.25f:
                    position = 0.0f;
                    break;
                case 0.0f:
                    position = -2.25f;
                    break;
            }

            speedY = -SPEED_Y;
        }
    }

    public void Invulnerable()
    {
        isVulnerable = false;
    }
}
