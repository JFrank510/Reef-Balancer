using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Vector3 direction;
    public float speed;
    public System.Action destroyed;

    void Start()
    {

    }

    private void Update(){
        this.transform.position += this.direction * this.speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.destroyed.Invoke();
 
        if (other.name == "LionFish(Clone)")
        {
            Vector2 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

            // Move Fish outside camera.
            float side = Random.Range(0, 10) > 5 ? -screenBounds.x - 5 : screenBounds.x + 5;
            other.gameObject.transform.position = new Vector2(side, Random.Range(0, screenBounds.y));

            // Change fish velocities.
            Fish theFish = other.gameObject.GetComponent<Fish>();
            theFish.speedX = Random.Range(1.0f, 3.0f);
            theFish.speedY = Random.Range(0.5f, 1.5f);

            // Update Score
            Score.updateScore(10);
            
            // Destroy projectile
            Destroy(this.gameObject);
        }
    }
}
