using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideNSeek : MonoBehaviour
{
    public GameObject CaughtPrefab;
    public GameObject MovePrefab;
    public UnityEngine.Rendering.Universal.Light2D light;
    public bool NightMode = false;

    private Vector2 screenBounds;
    private float ctdnw = 52.0f;

    public int maximum = 8;

    // Start is called before the first frame update
    void Start()
    {
        light = this.transform.GetComponent<UnityEngine.Rendering.Universal.Light2D>();

        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        for (int i = 0; i < maximum; i++) {
            float positionX = Random.Range(-screenBounds.x + 1, screenBounds.x - 1);
            float positionY = Random.Range(-1f, screenBounds.y - 1);

            CreateFish(positionX, positionY);
            CreateObstacle(positionX, positionY);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (ctdnw > 0) {
            ctdnw -= Time.deltaTime;
        }

        double b = System.Math.Round(ctdnw, 2);

        if (ctdnw < 50) {
            NightMode = true;
            light.intensity = 0.2f;
        }

        if (ctdnw < 0) {
            Debug.Log("Game Over");
        }
    }

    private void CreateFish(float positionX, float positionY)
    {
        GameObject a = Instantiate(CaughtPrefab) as GameObject;
        a.transform.position = new Vector2(positionX, positionY);
    }

    private void CreateObstacle(float positionX, float positionY)
    {
        GameObject b = Instantiate(MovePrefab) as GameObject;
        b.transform.position = new Vector2(positionX, positionY);
    }
}
