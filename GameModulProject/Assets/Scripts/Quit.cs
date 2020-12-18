using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quit : MonoBehaviour
{
    public float hoverTimer = 3f;

    private float timer = 3f;
    private bool timerStarted = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                timer = hoverTimer;
                Application.Quit(0);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        timer = hoverTimer;
        timerStarted = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        timer = hoverTimer;
        timerStarted = false;
    }
}
