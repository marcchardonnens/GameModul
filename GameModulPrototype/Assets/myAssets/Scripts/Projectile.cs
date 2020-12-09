using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public static int collisions = 0;
    public float speed = 20.0f;
    private Rigidbody2D rb;
    private Vector2 screenBounds;


    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, -speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.y < screenBounds.y * -2)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision is Projectile)
        collisions++;
        Debug.Log("Collisions: " + collisions.ToString());
    }

    private void OnGUI()
    {
        GUI.Label(new Rect(0, 0, 100, 20), "collisions: " + collisions.ToString());
    }
}
