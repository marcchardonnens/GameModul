using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alien : MonoBehaviour
{

    private GameManager game;
    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {


        if (transform.position.y < game.ScreenBounds.y * -3)
        {
            Destroy(this.gameObject);
        }
    }
}
