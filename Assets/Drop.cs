using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{
    private float speedY = -2.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;
    private OxygenBar ob;
    void Start()
    {
        ob = GameObject.Find("PlayerSpawn").GetComponent<OxygenBar>();
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        rb = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (this.transform.position.y < -screenBounds.y + 1.5) {
            speedY = 0.0f;
        }

        rb.velocity = new Vector2(0.0f, speedY);
    }

    void OnTriggerEnter2D(Collider2D player)
    {
        Destroy(this.gameObject);
        ob.UseTank();
    }
}
