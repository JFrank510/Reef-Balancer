using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshPowerUp : MonoBehaviour
{
    public int lives = 10;
    public bool isInUse = false;
    public float speedY = 0.0f;
    public float position = 0.0f;
    public float cndown = 3.0f;
    
    private float speedX = 5.0f;
    private float SPEED_Y = 5.0f;

    private Rigidbody2D rb;
    private Runner rn;
    private SpawnObstacles so;

    // Start is called before the first frame update
    void Start()
    {
        rn = GameObject.Find("Main Camera").GetComponent<Runner>();
        so = GameObject.Find("Main Camera").GetComponent<SpawnObstacles>();

        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speedX, speedY);
        rb.isKinematic = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInUse) {
            if (speedY == 0.0f && canChooseNewWay()) {
                SelectNewPosition();
                cndown = 3.0f;
            }

            // Stop the Mesh in the correct path.
            if (speedY > 0.0f && this.transform.position.y > position || speedY < 0.0f && this.transform.position.y < position) {
                speedY = 0.0f;
                rb.velocity = new Vector2(-speedX, speedY);
            }

            if (lives <= 0) {
                Destroy(this.gameObject);
                so.canSpawnPowerup = true;
            }
        }
    }

    // Check if we can select a new way
    bool canChooseNewWay()
    {
        cndown -= Time.deltaTime;
        return cndown < 0;
    }

    void SelectNewPosition()
    {
        int next = 1;
        float oldPosition = position;

        // Note Hector:
        // Random.Range(Min, MAX (Not inclusive)).

        /**
         * This allows to move freely between the three rows.
         */
        switch (position) {
            case 2.25f:
                // Choose one of three paths
                next = Random.Range(0, 3);
                position = position - (next * 2.25f);
                break;  
            case 0.0f:
                // Choose one of three paths
                next = Random.Range(-1, 2);
                position = position + (next * 2.25f);
                break;
            case -2.25f:
                // choose one of three paths
                next = Random.Range(0, 3);
                position = position + (next * 2.25f);
                break;  
        }

        // We require the old position to determine which 
        // speedY we require, positive, 0 or negative.
        if (oldPosition == position) {
            // dont move
            speedY = 0;
        } else if (oldPosition < position) {
            // go up
            speedY = SPEED_Y;
        } else if (oldPosition > position) {
            // go down
            speedY = -SPEED_Y;
        }

        rb.velocity = new Vector2(-speedX, speedY);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isInUse) {
            if (other.name == "Player") {
                isInUse = true;
                speedX = 0.0f;

                rb.velocity = new Vector2(speedX, speedY);
                this.transform.position = new Vector2(this.transform.position.x + 1, 0.0f);
            } else {
                Destroy(this.gameObject);
                so.canSpawnPowerup = true;
            }
        } else {
            if (other.name == "Trash(Clone)") {
                Destroy(other.gameObject);
                rn.AddPoints(10 * lives);
                lives--;
            }
        }
    }
}
