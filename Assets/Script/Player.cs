using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Projectile redPrefab;
    public float speed = 5.0f;
    private bool _redActive;

    private float boundaryXMin = -10f;
    private float boundaryXMax = 10f;

    private float boundaryYMin = -4f;
    
    private float boundaryYMax = -4f;

    private void Update()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 direction = new Vector3(horizontalInput,verticalInput);
        transform.Translate(speed * Time.deltaTime * direction);
        // if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
        //     this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        // }
        // else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
        //     this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        // }

        if(Input.GetKeyDown(KeyCode.Space)){
            shoot();
        }
        direction.x = Mathf.Clamp(transform.position.x, boundaryXMin, boundaryXMax);
        direction.y = Mathf.Clamp(transform.position.y, boundaryYMin, boundaryYMax);
        transform.position = direction;
    }

    private void shoot(){
        if(!_redActive){

            Projectile projectile = Instantiate(this.redPrefab, this.transform.position, Quaternion.identity);
            projectile.destroyed += RedDestroyed;
            _redActive = true;
        }
    }

    private void RedDestroyed(){
        _redActive = false;

    }


}

