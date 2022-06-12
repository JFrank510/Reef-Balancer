using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Projectile redPrefab;
    public float speed = 5.0f;
    private bool _redActive;
    private void Update()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) {
            this.transform.position += Vector3.left * this.speed * Time.deltaTime;
        }
        else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) {
            this.transform.position += Vector3.right * this.speed * Time.deltaTime;
        }

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)){
            shoot();
        }
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

