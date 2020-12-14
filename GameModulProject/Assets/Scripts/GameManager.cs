using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    //Prefab fields
    public GameObject Asteroid;
    public GameObject Objective;
    public GameObject[] Powerups;
    public GameObject[] Upgrades;
    public GameObject[] Bombs;
    public GameObject player;


    public StageInterface CurrentStage { get; private set; }
    private PlayerController playerController;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public Vector2 ScreenBounds { get; private set; }
    public Vector2 PlayerBounds { get; private set; }

    private GameState gameState;
    private GameState nextGameState = GameState.Default;
    private float waitTimer = 0f;


    public void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }

        gameState = GameState.InitiateStage1;
        

        ScreenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        //Player bounds might be adjusted later
        PlayerBounds = ScreenBounds;


    }

    private void Start()
    {
        playerController = player.GetComponent<PlayerController>();
    }

    private void Wait(float timer, GameState nextState)
    {
        waitTimer = timer;
        gameState = GameState.Wait;
        nextGameState = nextState;
    }

    private void Update()
    {
        switch (gameState)
        {
            case GameState.Default:
                break;
            case GameState.Wait:
                if(waitTimer > 0)
                {
                    waitTimer -= Time.deltaTime;
                }
                else
                {
                    gameState = nextGameState;
                    nextGameState = GameState.Default;
                }
                break;
            case GameState.StartScreen:
                break;
            case GameState.InitiateStage1:
                CurrentStage = StageFactory.CreateStage1Manager(this.gameObject, Asteroid, Objective, Powerups);
                CurrentStage.EnterStage();
                gameState = GameState.Stage1;
                break;
            case GameState.Stage1:
                CurrentStage.ExecuteStage();
                if(EndingConditionReached())
                {
                    CurrentStage.SetStageResult(StageResult.Win);
                    gameState = GameState.EndStage1;
                }
                break;
            case GameState.EndStage1:
                CurrentStage.EndStage();
                Wait(5, GameState.InitiateIntermission1);
                break;
            case GameState.InitiateIntermission1:
                Debug.Log("Start Intermission 1");
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


    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
    }

    public GameState GetGameState()
    {
        return gameState;
    }


    private bool EndingConditionReached()
    {

        if(playerController.Health <= 0)
        {
            return true;
        }
        if(CurrentStage.WinConditionReached())
        {
            return true;
        }


        return false;
    }





    public enum GameState
    {
        Default,
        Wait,
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
