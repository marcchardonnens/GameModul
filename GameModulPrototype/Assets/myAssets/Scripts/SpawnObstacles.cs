using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{
    public GameObject item;
    public GameObject projectile;
    public float delay = 1.0f;
    private Vector2 screenBounds;

    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        InvokeRepeating("SpawnProjectile", delay, delay);
        SpawnCollectable();
        

    }

    public void SpawnCollectable()
    {
        item = Instantiate(item) as GameObject;
        item.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
    }


    private void SpawnProjectile()
    {
        GameObject go = Instantiate(projectile) as GameObject;
        go.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), screenBounds.y * 2);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
