using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    public float cndwn = 10.0f;

    // Update is called once per frame
    void Update()
    {
        cndwn -= Time.deltaTime;

        if (cndwn < 0) {
            Destroy(this.gameObject);
        }
    }
}
