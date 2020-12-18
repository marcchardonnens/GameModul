using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinematicChild : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0.1f, 0, 0);
        transform.Rotate(new Vector3(0, 0, -1f));

        if(transform.position.x > GameManager.Instance.ScreenBounds.x *2)
        {
            Destroy(this.gameObject);
        }
    }
}
