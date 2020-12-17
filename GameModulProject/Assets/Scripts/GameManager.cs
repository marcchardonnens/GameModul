using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    
    //Prefab fields
    public GameObject[] Obstacles;
    public GameObject Objective;
    public GameObject[] Powerups;
    public GameObject ShieldUpgrade;
    public GameObject SpeedUpgrade;
    public GameObject Alien;
    public GameObject[] Bombs;
    public GameObject player;
    public AudioClip AudioStageComplete;
    public AudioClip AudioGameOver;



    public StageInterface CurrentStage { get; private set; }
    public PlayerController playerController { get; private set; }
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }
    public Vector2 ScreenBounds { get; private set; }
    public Vector2 PlayerBounds { get; private set; }

    private GameState gameState;
    private GameState nextGameState = GameState.Default;
    private float waitTimer = 0f;

    private bool playerHasShieldUpgrade = false;
    private bool playerHasSpeedUpgrade = false;

    private IntermissionStage intermissionStage;

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

        gameState = GameState.StartScreen;


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
                GUIManager.Instance.OnTitleScreen();
                playerController.RefillHealth();
                break;
            case GameState.StartGame:

                GUIManager.Instance.OnGameStart();

                //Fade out/in animation maybe

                Wait(1, GameState.InitiateStage1);

                break;
            case GameState.Endgame:
                
                List<MonoBehaviour> objects = new List<MonoBehaviour>(FindObjectsOfType<Asteroid>());
                objects.AddRange(FindObjectsOfType<PowerupAbstract>());
                objects.AddRange(FindObjectsOfType<Objective>());
                foreach (MonoBehaviour obj in objects)
                {
                    Destroy(obj.gameObject);
                }
                playerHasShieldUpgrade = false;
                playerHasSpeedUpgrade = false;
                Wait(4, GameState.StartScreen);
                break;
            case GameState.InitiateStage1:
                CurrentStage = StageFactory.CreateStage1Manager(this.gameObject, Obstacles, Objective, Powerups);
                CurrentStage.EnterStage();
                gameState = GameState.Stage1;
                break;
            case GameState.Stage1:
                CurrentStage.ExecuteStage();
                if(EndingConditionReached())
                {
                    gameState = GameState.EndStage1;
                }
                break;
            case GameState.EndStage1:
                CurrentStage.EndStage();
                if(CurrentStage.GetStageResult() == StageResult.Win)
                {
                    Wait(5, GameState.InitiateIntermission1);
                }
                else
                {
                    //Wait(5, GameState.Endgame);
                    gameState = GameState.Endgame;
                }
                //CurrentStage.ResetObjectiveCounter();
                break;
            case GameState.InitiateIntermission1:
                intermissionStage = StageFactory.CreateIntermissionStage(this.gameObject, ShieldUpgrade, SpeedUpgrade, Alien);
                intermissionStage.EnterStage();
                gameState = GameState.Intermission1;
                break;
            case GameState.Intermission1:
                if(intermissionStage.PlayerHasChosen())
                {
                    CurrentStage.ResetObjectiveCounter();
                    CurrentStage = null;
                    gameState = GameState.EndIntermission1;
                }
                break;
            case GameState.EndIntermission1:
                intermissionStage.EndStage();
                gameState = GameState.InitiateStage2;
                break;
            case GameState.InitiateStage2:
                CurrentStage = StageFactory.CreateStage2Manager(this.gameObject, Obstacles, Objective, Powerups);
                CurrentStage.EnterStage();
                gameState = GameState.Stage2;
                break;
            case GameState.Stage2:
                CurrentStage.ExecuteStage();
                if (EndingConditionReached())
                {
                    gameState = GameState.EndStage2;
                }
                break;
            case GameState.EndStage2:
                CurrentStage.EndStage();
                if (CurrentStage.GetStageResult() == StageResult.Win)
                {
                    Wait(5, GameState.InitiateIntermission2);
                }
                else
                {
                    //Wait(5, GameState.Endgame);
                    gameState = GameState.Endgame;
                }
                //CurrentStage.ResetObjectiveCounter();
                break;
            case GameState.InitiateIntermission2:
                intermissionStage = StageFactory.CreateIntermissionStage(this.gameObject, ShieldUpgrade, SpeedUpgrade, Alien);
                intermissionStage.EnterStage();
                gameState = GameState.Intermission2;
                break;
            case GameState.Intermission2:
                if (intermissionStage.PlayerHasChosen())
                {
                    CurrentStage.ResetObjectiveCounter();
                    gameState = GameState.EndIntermission2;
                }
                break;
            case GameState.EndIntermission2:
                intermissionStage.EndStage();
                gameState = GameState.InitiateStage3;
                break;
            case GameState.InitiateStage3:
                CurrentStage = StageFactory.CreateStage3Manager(this.gameObject, Obstacles, Objective, Powerups);
                CurrentStage.EnterStage();
                gameState = GameState.Stage3;
                break;
            case GameState.Stage3:
                CurrentStage.ExecuteStage();
                if (EndingConditionReached())
                {
                    gameState = GameState.EndStage3;
                }
                break;
            case GameState.EndStage3:
                CurrentStage.EndStage();
                if (CurrentStage.GetStageResult() == StageResult.Win)
                {
                    Wait(5, GameState.InitiateStage3);
                }
                else
                {
                    //Wait(5, GameState.Endgame);
                    gameState = GameState.Endgame;
                }
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

    public void StartGame()
    {
        gameState = GameState.StartGame;
    }


    public void SetGameState(GameState gameState)
    {
        this.gameState = gameState;
    }

    public GameState GetGameState()
    {
        return gameState;
    }

    public void ApplyShieldUpgrade()
    {
        intermissionStage.SignalPlayerChoice();
        playerHasShieldUpgrade = true;
        playerController.ApplyShieldUpgrade();
    }

    public void ApplySpeedUpgrade()
    {
        intermissionStage.SignalPlayerChoice();
        playerHasSpeedUpgrade = true;
        playerController.ApplySpeedUpgrade();
    }

    public bool HasShieldUpgrade()
    {
        return playerHasShieldUpgrade;
    }

    public bool HasSpeedUpgrade()
    {
        return playerHasSpeedUpgrade;
    }


    private bool EndingConditionReached()
    {

        if(playerController.Health <= 0)
        {
            CurrentStage.SetStageResult(StageResult.Loss);
            AudioManager.Instance.PlaySound(AudioGameOver);
            return true;
        }
        if(CurrentStage.WinConditionReached())
        {

            CurrentStage.SetStageResult(StageResult.Win);
            AudioManager.Instance.PlaySound(AudioStageComplete);
            return true;
        }


        return false;
    }





    public enum GameState
    {
        Default,
        Wait,
        StartScreen,
        StartGame,
        Endgame,



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
