using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Manager : MonoBehaviour,StageInterface
{

    //Obstacles
    public float asteroidDelay = 1f;
    public float asteroidRepeat = 1f;
    public int asteroidAmountMin = 1;
    public int asteroidAmountMax = 4;
    public float movementXmin = -1;
    public float movementXmax = -1;
    public float movementYmin = -0.25f;
    public float movementYmax = 0.25f;
    public float speedMin = 5f;
    public float speedMax = 15f;
    public float scaleMin = 0.5f;
    public float scaleMax = 2.5f;

    public int objectiveLimit = 5;
    public float objectiveSpawnDelay = 5f;

    public float PowerupSpawnDelay = 5f;


    private GameObject Objective;
    private GameObject Asteroid;
    private GameObject[] Powerups;
    private GameManager game;

    public StageResult result { get; set; } = StageResult.Default;

    private static float spawnOffset = 2;

    private int objectiveCounter;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.Instance;
    }

    public void SetAsteroid(GameObject Asteroid)
    {
        this.Asteroid = Asteroid;
    }
    public void SetObjective(GameObject Objective)
    {
        this.Objective = Objective;
    }

    public void SetPowerups(GameObject[] Powerups)
    {
        this.Powerups = Powerups;
    }




    public void SpawnObstacles()
    {
        int obstacleAmount = Random.Range(asteroidAmountMin, asteroidAmountMax);
        for (int i = 0; i < obstacleAmount; i++)
        {
            GameObject ago = Instantiate(Asteroid, new Vector3(game.ScreenBounds.x * spawnOffset, Random.Range(-game.ScreenBounds.y, game.ScreenBounds.y)), Quaternion.identity);
            Asteroid a = ago.GetComponent<Asteroid>();
            a.SetMovement(new Vector2(Random.Range(movementXmin,movementXmax), Random.Range(movementYmin,movementYmax)));
            a.SetSpeed(Random.Range(5f, 15f));
            float scaleAmount = Random.Range(0.5f, 2.5f);
            a.transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);

            //asteroid.SendMessage
        }
    }

    public void SpawnPowerups()
    {
        GameObject go = Instantiate(Powerups[Random.Range(0, 2)], new Vector3(Random.Range(-game.PlayerBounds.x, game.PlayerBounds.x), Random.Range(-game.PlayerBounds.y, game.PlayerBounds.y)), Quaternion.identity);
        Debug.Log("Powerup Spawned");

    }

    public void SpawnObjective()
    {
        GameObject go = Instantiate(Objective, new Vector3(Random.Range(-game.PlayerBounds.x, game.PlayerBounds.x), Random.Range(-game.PlayerBounds.y, game.PlayerBounds.y)), Quaternion.identity);
        //Objective obj = go.GetComponent<Objective>();

        Debug.Log("Objective Spawned");
        
    }

    public void EnterStage()
    {
        InvokeRepeating("SpawnObstacles", asteroidDelay, asteroidRepeat);
        InvokeRepeating("SpawnPowerups", PowerupSpawnDelay, PowerupSpawnDelay);
        Invoke("SpawnObjective", objectiveSpawnDelay);
    }

    public void EndStage()
    {

        //stop invoke repeating calls

        CancelInvoke("SpawnObstacles");
        CancelInvoke("SpawnPowerups");
    }

    public void ExecuteStage()
    {
        //thigs to do every loop
    }

    public bool WinConditionReached()
    {
        return objectiveCounter >= objectiveLimit;
    }

    public void ObjectiveCollected()
    {
        objectiveCounter++;
        if (!WinConditionReached())
        {
            Invoke("SpawnObjective", objectiveSpawnDelay);
        }
    }

    public void SetStageResult(StageResult result)
    {
        this.result = result;
    }
}
