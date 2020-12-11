using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    //Prefab fields
    public GameObject[] Asteroid;
    public GameObject[] Powerups;
    public GameObject[] Player;
    public GameObject[] QuestItems;
    public GameObject[] Upgrades;
    public GameObject[] Bombs;



    private Stage1Manager stage1Manager;
    private PlayerController playerController;
    public static GameManager instance;
    public Vector2 ScreenBounds { get; }
    public Vector2 PlayerBounds { get; }

    private GameState gameState;

    // make sure the constructor is private, so it can only be instantiated here
    private GameManager()
    {
        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Player bounds might be adjusted later
        PlayerBounds = ScreenBounds;

        
    }



    private void Update()
    {
        switch (gameState)
        {
            case GameState.Default:
                break;
            case GameState.StartScreen:
                break;
            case GameState.InitiateStage1:
                //Create stage1 manager

                break;
            case GameState.Stage1:
                break;
            case GameState.EndStage1:
                //kill stage 1 manager
                break;
            case GameState.InitiateIntermission1:
                break;
            case GameState.Intermission1:
                break;
            case GameState.EndIntermission1:
                break;
            case GameState.InitiateStage2:
                break;
            case GameState.Stage2:
                break;
            case GameState.EndStage2:
                break;
            case GameState.InitiateIntermission2:
                break;
            case GameState.Intermission2:
                break;
            case GameState.EndIntermission2:
                break;
            case GameState.InitiateStage3:
                break;
            case GameState.Stage3:
                break;
            case GameState.EndStage3:
                break;
            case GameState.InitiateIntermission3:
                break;
            case GameState.Intermission3:
                break;
            case GameState.EndIntermission3:
                break;
            default:
                break;
        }

    }


    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
    }

    public GameState GetGameState()
    {
        return gameState;
    }



    private void SpawnQuestObjects()
    {

    }


    private void SpawnObstacles()
    {

    }

    private void SpawnPowerups()
    {

    }


    


    public enum GameState
    {
        Default,
        StartScreen,
        InitiateStage1,
        Stage1,
        EndStage1,
        InitiateIntermission1,
        Intermission1,
        EndIntermission1,
        InitiateStage2,
        Stage2,
        EndStage2,
        InitiateIntermission2,
        Intermission2,
        EndIntermission2,
        InitiateStage3,
        Stage3,
        EndStage3,
        InitiateIntermission3,
        Intermission3,
        EndIntermission3,
    }
}
