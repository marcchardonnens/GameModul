using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeShield : MonoBehaviour
{

    public float hoverTimer = 3f;
    public AudioClip sound;

    private float timer = 3f;
    private bool timerStarted = false;
    private GameManager game;

    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.Instance;
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
                AudioManager.Instance.PlaySound(sound);
                game.ApplyShieldUpgrade();
                Destroy(this.gameObject);
            }
        }



        if (transform.position.y < game.ScreenBounds.y * -3)
        {
            Destroy(this.gameObject);
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
