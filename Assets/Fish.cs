using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float speedX = 2.0f;
    public float speedY = 1.0f;
    public bool facingRight = true;

    private Rigidbody2D rb;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speedX, speedY);
        rb.isKinematic = false;

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        float x = speedX > 0 ? speedX : -speedX;
        float y = speedY > 0 ? speedY : -speedY;

        if (transform.position.x < -(screenBounds.x * 0.90)) {
            speedX = x;
        }

        if (transform.position.x > (screenBounds.x * 0.90)) {
            speedX = -x;
        }

        
        if (transform.position.y > (screenBounds.y * 0.90)) {
            speedY = -y;
        }

        if (transform.position.y < 0) {
            speedY = y;
        }

        if (speedX > 0 && !facingRight || speedX < 0 && facingRight) {
            Flip();
        }

        rb.velocity = new Vector2(speedX, speedY);
    }

    void Flip()
    {
        Vector3 currentScale = gameObject.transform.localScale;
        currentScale.x *= -1;

        gameObject.transform.localScale = currentScale;
        facingRight = !facingRight;
    }
}
