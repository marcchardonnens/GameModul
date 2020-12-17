using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntermissionStage : MonoBehaviour
{
    private const float speed = 2f;
    private GameObject speedUpgrade;
    private GameObject shieldUpgrade;
    private GameObject alien;

    private bool playerHasChosen = false;

    private GameManager game;

    private IntermissionState state;


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
                    speedUpgrade.transform.position += new Vector3(-1f, 0, 0);// * speed;
                    shieldUpgrade.transform.position += new Vector3(-1f, 0, 0);// * speed;
                    alien.transform.position += new Vector3(-1f, 0, 0);// * speed;
                }
                else
                {
                    speedUpgrade.transform.position = new Vector3(-5, 3, 1);
                    shieldUpgrade.transform.position = new Vector3(5, 3, 1);
                    alien.transform.position = new Vector3(7, -2, 1);
                    //state = IntermissionState.PlayerChoosing;

                }
                break;
            case IntermissionState.PlayerChoosing:

                //if(playerHasChosen)
                //{
                //    state = IntermissionState.AlienLeaving;
                //}


                break;
            case IntermissionState.AlienLeaving:
                speedUpgrade.transform.position += new Vector3(0, -speed, 0);
                shieldUpgrade.transform.position += new Vector3(0, -speed, 0);
                alien.transform.position += new Vector3(0, -speed, 0);
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
            Instantiate(speedUpgrade, new Vector3(game.ScreenBounds.x * 2, 3), Quaternion.identity);
        }
        if(!game.HasShieldUpgrade())
        {
            Instantiate(shieldUpgrade, new Vector3(game.ScreenBounds.x * 2 + 10, 3), Quaternion.identity);
        }
        Instantiate(alien, new Vector3(game.ScreenBounds.x * 2 + 12, -2), Quaternion.identity);
        state = IntermissionState.AlienEntering;
    }


    public void EndStage()
    {
        state = IntermissionState.AlienLeaving;
    }


    public bool PlayerHasChosen()
    {
        return playerHasChosen;
    }














    public void SetSpeedUpgrade(GameObject speedUpgrade)
    {
        this.speedUpgrade = speedUpgrade;
    }

    public void SetShieldUpgrade(GameObject shieldUpgrade)
    {
        this.shieldUpgrade = shieldUpgrade;
    }

    public void SetAlien(GameObject alien)
    {
        this.alien = alien;
    }


    private enum IntermissionState
    {
        Default,
        AlienEntering,
        PlayerChoosing,
        AlienLeaving
    }



}
