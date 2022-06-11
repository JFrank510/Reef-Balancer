using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] 
    private float speed = 100f;
    private void Update()
    {
        if (Input.GetKey(KeyCode.D)) 
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.A)) 
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
    }
}
