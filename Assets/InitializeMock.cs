using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitializeMock : MonoBehaviour
{
    public GameObject LionFishPrefab;
    private Vector2 screenBounds;
    
    public int maximum = 10;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        createMock();
    }

    private void spawnEnemy()
    {
        GameObject a = Instantiate(LionFishPrefab) as GameObject;
        a.transform.position = new Vector2(Random.Range(-screenBounds.x , screenBounds.x), Random.Range(0, screenBounds.y));
    }

    private void createMock()
    {
        for (int i = 0; i < maximum; i++) {
            spawnEnemy();
        }
    }
}
