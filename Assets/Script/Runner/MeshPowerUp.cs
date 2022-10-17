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
        // if power up is in use
        if (isInUse) {
            // if is stopped and can change its way
            if (speedY == 0.0f && canChooseNewWay()) {
                // select a new position
                SelectNewPosition();
                // restart cooldown for choose new way
                cndown = 3.0f;
            }

            // stop the mesh when reached the desired point
            if (speedY > 0.0f && this.transform.position.y > position || speedY < 0.0f && this.transform.position.y < position) {
                speedY = 0.0f;
                rb.velocity = new Vector2(-speedX, speedY);
            }

            // if all lives of item are exhausted, destroy the object
            if (lives <= 0) {
                Destroy(this.gameObject);

                // spawner can show a new powerup
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

        // Note: Random.Range(a, b); 
        //  B is not inclusive, so we can add one more.
        switch (position) {
            case 2.25f:
                // Choose one of three paths
                next = Random.Range(0, 3);
                
                // going down
                position = position - (next * 2.25f);
                break;  
            case 0.0f:
                // Choose one of three paths
                next = Random.Range(-1, 2);
                
                // going up or down
                position = position + (next * 2.25f);
                break;
            case -2.25f:
                // choose one of three paths
                next = Random.Range(0, 3);
                
                // going up
                position = position + (next * 2.25f);
                break;  
        }

        // use oldPosition to determine the Y velocity.
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
        // if mesh is not being used
        if (!isInUse) {
            // if collides with player
            if (other.name == "Player") {
                // start using
                isInUse = true;

                // adjust velocity and position
                speedX = 0.0f;
                rb.velocity = new Vector2(speedX, speedY);
                this.transform.position = new Vector2(this.transform.position.x + 1, 0.0f);
            } 
            // if collides with another thing
            else {
                // destroy the item
                Destroy(this.gameObject);
                so.canSpawnPowerup = true;
            }
        } 
        // if is being used
        else {
            // when colliding with trash destroy the game object and set new score.
            if (other.name == "Trash(Clone)") {
                Destroy(other.gameObject);
                rn.AddPoints(10 * lives);
                lives--;
            }
        }
    }
}
