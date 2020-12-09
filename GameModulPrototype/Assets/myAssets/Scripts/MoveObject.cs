using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    
    public bool followCursor = true;
    private Vector3 screenBounds;


    // Start is called before the first frame update
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width -30, Screen.height-30, Camera.main.transform.position.z));
    }

    void Update()
    {
            
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        if(followCursor)
        {
            moveObjectToCursor();
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

    }





    private void moveObjectToCursor()
    {
        Vector3 cam = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = new Vector3();
        newPos.z = 0;

        if (cam.x > -screenBounds.x && cam.x < screenBounds.x)
        {
            newPos.x = cam.x;
        }
        else if (cam.x <= -screenBounds.x)
        {
            newPos.x = -screenBounds.x;
        }
        else if (cam.x >= screenBounds.x)
        {
            newPos.x = screenBounds.x;
        }
        if (cam.y > -screenBounds.y && cam.y < screenBounds.y)
        {
            newPos.y = cam.y;
        }
        else if (cam.y <= -screenBounds.y)
        {
            newPos.y = -screenBounds.y;
        }
        else if (cam.y >= screenBounds.y)
        {
            newPos.y = screenBounds.y;
        }


        transform.position = newPos;

        //Debug.Log(cam.ToString());
        //Debug.Log(transform.position.ToString());
    }
}
