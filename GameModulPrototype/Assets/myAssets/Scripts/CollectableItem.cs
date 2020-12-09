using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableItem : MonoBehaviour
{
    
    public static int itemsCollected = 0;
    private Vector2 screenBounds;
    private SpawnObstacles manager;
    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        manager = FindObjectOfType<SpawnObstacles>();
    }



    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        itemsCollected++;
        
        manager.SpawnCollectable();
        Destroy(this.gameObject);
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 20, 100, 20), "collected: " + itemsCollected.ToString());
    }

}
