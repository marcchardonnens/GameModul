using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermissionStage : MonoBehaviour
{
    private GameObject PFspeedUpgrade;
    private GameObject PFshieldUpgrade;
    private GameObject PFalien;

    private const float speed = 0.25f;
    private GameObject speedUpgrade;
    private GameObject shieldUpgrade;
    private GameObject alien;

    private bool playerHasChosen = false;

    private GameManager game;

    private IntermissionState state;


    private void Awake()
    {
        state = IntermissionState.Default;
    }


    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        switch (state)
        {
            case IntermissionState.AlienEntering:
                if(speedUpgrade.transform.position.x > -5)
                {
                    //speedUpgrade.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));
                    //shieldUpgrade.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));
                    //alien.GetComponent<Rigidbody2D>().AddForce(new Vector2(-speed, 0));
                    if(speedUpgrade != null)
                    {
                        speedUpgrade.transform.position += new Vector3(-1f, 0, 0) * speed;
                    }
                    if(shieldUpgrade != null)
                    {
                        shieldUpgrade.transform.position += new Vector3(-1f, 0, 0) * speed;
                    }
                    if(alien != null)
                    {
                        alien.transform.position += new Vector3(-1f, 0, 0) * speed;
                    }
                }
                else
                {
                    //speedUpgrade.transform.position = new Vector3(-5, 3, 1);
                    //shieldUpgrade.transform.position = new Vector3(5, 3, 1);
                    //alien.transform.position = new Vector3(7, -2, 1);
                    state = IntermissionState.PlayerChoosing;

                }
                break;
            case IntermissionState.PlayerChoosing:

                if (playerHasChosen)
                {
                    state = IntermissionState.AlienLeaving;
                }


                break;
            case IntermissionState.AlienLeaving:

                if (speedUpgrade != null)
                {
                    speedUpgrade.transform.position += new Vector3(0, -1f, 0) * speed;
                }
                if (shieldUpgrade != null)
                {
                    shieldUpgrade.transform.position += new Vector3(0, -1f, 0) * speed;
                }
                if (alien != null)
                {
                    alien.transform.position += new Vector3(0, -1f, 0) * speed;
                }
                break;
            default:
                break;
        }
    }


    public void EnterStage()
    {
        game = GameManager.Instance;
        if (!game.HasSpeedUpgrade())
        { 
            speedUpgrade = Instantiate(PFspeedUpgrade, new Vector3(game.ScreenBounds.x * 2, 3), Quaternion.identity);
        }
        if(!game.HasShieldUpgrade())
        {
            shieldUpgrade = Instantiate(PFshieldUpgrade, new Vector3(game.ScreenBounds.x * 2 + 10, 3), Quaternion.identity);
        }
         alien = Instantiate(PFalien, new Vector3(game.ScreenBounds.x * 2 + 12, -2), Quaternion.identity);
        state = IntermissionState.AlienEntering;
    }


    public void EndStage()
    {
        state = IntermissionState.AlienLeaving;
    }

    public void SignalPlayerChoice()
    {
        playerHasChosen = true;
    }

    public bool PlayerHasChosen()
    {
        return playerHasChosen;
    }














    public void SetSpeedUpgrade(GameObject speedUpgrade)
    {
        this.PFspeedUpgrade = speedUpgrade;
    }

    public void SetShieldUpgrade(GameObject shieldUpgrade)
    {
        this.PFshieldUpgrade = shieldUpgrade;
    }

    public void SetAlien(GameObject alien)
    {
        this.PFalien = alien;
    }


    private enum IntermissionState
    {
        Default,
        AlienEntering,
        PlayerChoosing,
        AlienLeaving
    }



}
