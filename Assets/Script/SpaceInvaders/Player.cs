using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Projectile redPrefab;
    public float speed = 5.0f;
    private bool _redActive;

    private float boundaryXMin = -9f;
    private float boundaryXMax = 9f;

    private float boundaryYMin = -4f;
    
    private float boundaryYMax = -4f;

    private bool flipleft = true; 

    private void Update()
    {
        move();
        shoot();
    }

    private void move()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput,verticalInput);
        transform.Translate(speed * Time.deltaTime * direction);
        direction.x = Mathf.Clamp(transform.position.x, boundaryXMin, boundaryXMax);
        direction.y = Mathf.Clamp(transform.position.y, boundaryYMin, boundaryYMax);
        transform.position = direction;
        flip(horizontalInput);
    }

    private void shoot()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if(!_redActive)
            {

                Projectile projectile = Instantiate(this.redPrefab, this.transform.position, Quaternion.identity);
                projectile.destroyed += RedDestroyed;
                _redActive = true;
            }
        }    
    }

    private void RedDestroyed()
    {
        _redActive = false;

    }

    private void flip(float horizontalInput)
    {
        if((flipleft == true && horizontalInput < 0) || (flipleft == false && horizontalInput > 0))
        {
            flipleft = !flipleft;
            transform.localScale = new Vector3(-transform.localScale.x,transform.localScale.y);

        }
    }


}

