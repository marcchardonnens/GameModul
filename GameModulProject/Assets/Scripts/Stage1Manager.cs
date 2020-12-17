using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage1Manager : MonoBehaviour, StageInterface
{
    public const float speedUpgradeModifier = 0.75f;

    //Obstacles
    public float asteroidDelay = 1f;
    public float asteroidRepeat = 1f;
    public int asteroidAmountMin = 2;
    public int asteroidAmountMax = 4;
    public float asteroidMovementXmin = -1;
    public float asteroidMovementXmax = -1;
    public float asteroidMovementYmin = -0.25f;
    public float asteroidMovementYmax = 0.25f;
    public float asteroidSpeedMin = 5f;
    public float asteroidSpeedMax = 15f;
    public float asteroidScaleMin = 3f;
    public float asteroidScaleMax = 4f;

    public float frachtDelay = 1f;
    public float frachtRepeat = 1f;
    public int frachtAmountMin = 2;
    public int frachtAmountMax = 4;
    public float frachtMovementXmin = -1;
    public float frachtMovementXmax = -1;
    public float frachtMovementYmin = -0.25f;
    public float frachtMovementYmax = 0.25f;
    public float frachtSpeedMin = 5f;
    public float frachtSpeedMax = 15f;
    public float frachtScaleMin = 1.5f;
    public float frachtScaleMax = 2.5f;

    public float messerDelay = 1f;
    public float messerRepeat = 1f;
    public int messerAmountMin = 2;
    public int messerAmountMax = 4;
    public float messerMovementXmin = -1;
    public float messerMovementXmax = -1;
    public float messerMovementYmin = -0.25f;
    public float messerMovementYmax = 0.25f;
    public float messerSpeedMin = 5f;
    public float messerSpeedMax = 15f;
    public float messerScaleMin = 0.25f;
    public float messerScaleMax = 1f;

    public int objectiveLimit = 1;
    public float objectiveSpawnDelay = 5f;

    public float PowerupSpawnDelay = 5f;


    private GameObject Objective;
    private GameObject[] Obstacles;
    private GameObject[] Powerups;
    private GameManager game;

    private StageResult result = StageResult.Default;

    private static float spawnOffset = 2;

    private int objectiveCounter = 0;

    void Awake()
    {
    }

    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.Instance;
    }

    public void SetObstacles(GameObject[] Obstacles)
    {
        this.Obstacles = Obstacles;
    }
    public void SetObjective(GameObject Objective)
    {
        this.Objective = Objective;
    }

    public void SetPowerups(GameObject[] Powerups)
    {
        this.Powerups = Powerups;
    }
    private Vector3 spawnPoint()
    {
        return new Vector3(game.ScreenBounds.x * spawnOffset, Random.Range(-game.ScreenBounds.y, game.ScreenBounds.y));
    }

    public void SpawnObstacles()
    {
        InvokeRepeating("SpawnAsteroids", asteroidDelay, asteroidRepeat);
        InvokeRepeating("SpawnFracht", frachtDelay, frachtRepeat);
        InvokeRepeating("SpawnMesser", messerDelay, messerRepeat);
    }

    public void SpawnAsteroids()
    {
        GameObject asteroid = Obstacles[0];
        int asteroidAmount = Random.Range(asteroidAmountMin, asteroidAmountMax);
        for (int i = 0; i < asteroidAmount; i++)
        {
            GameObject ago = Instantiate(asteroid, spawnPoint(), Quaternion.identity);
            Asteroid a = ago.GetComponent<Asteroid>();
            a.SetMovement(new Vector2(Random.Range(asteroidMovementXmin, asteroidMovementXmax), Random.Range(asteroidMovementYmin, asteroidMovementYmax)));
            float speed = Random.Range(asteroidSpeedMin, asteroidSpeedMax);
            if (game.HasSpeedUpgrade())
            {
                speed *= speedUpgradeModifier;
            }
            a.SetSpeed(speed);
            float scaleAmount = Random.Range(asteroidScaleMin, asteroidScaleMax);
            a.transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);
        }
    }

    public void SpawnFracht()
    {
        GameObject fracht = Obstacles[1];
        int frachtAmount = Random.Range(frachtAmountMin, frachtAmountMax);
        for (int i = 0; i < frachtAmount; i++)
        {
            GameObject ago = Instantiate(fracht, spawnPoint(), Quaternion.identity);
            Asteroid a = ago.GetComponent<Asteroid>();
            a.SetMovement(new Vector2(Random.Range(frachtMovementXmin, frachtMovementXmax), Random.Range(frachtMovementYmin, frachtMovementYmax)));
            float speed = Random.Range(frachtSpeedMin, frachtSpeedMax);
            if (game.HasSpeedUpgrade())
            {
                speed *= speedUpgradeModifier;
            }
            a.SetSpeed(speed);
            float scaleAmount = Random.Range(frachtScaleMin, frachtScaleMax);
            a.transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);
        }
    }

    public void SpawnMesser()
    {
        GameObject messer = Obstacles[2];
        int messerAmount = Random.Range(messerAmountMin, messerAmountMax);
        for (int i = 0; i < messerAmount; i++)
        {
            GameObject ago = Instantiate(messer, spawnPoint(), Quaternion.identity);
            Asteroid a = ago.GetComponent<Asteroid>();
            a.SetMovement(new Vector2(Random.Range(messerMovementXmin, messerMovementXmax), Random.Range(messerMovementYmin, messerMovementYmax)));
            float speed = Random.Range(messerSpeedMin, messerSpeedMax);
            if (game.HasSpeedUpgrade())
            {
                speed *= speedUpgradeModifier;
            }
            a.SetSpeed(speed);
            float scaleAmount = Random.Range(messerScaleMin, messerScaleMax);
            a.transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);
        }
    }



    public void SpawnPowerups()
    {
        GameObject go = Instantiate(Powerups[Random.Range(0, Powerups.Length)], spawnPoint(), Quaternion.identity);
        PowerupAbstract pa = go.GetComponent<PowerupAbstract>();
        pa.SetDirection(new Vector2(-1, 0));

    }

    public void SpawnObjective()
    {
        GameObject go = Instantiate(Objective, new Vector3(Random.Range(-game.PlayerBounds.x, game.PlayerBounds.x), Random.Range(-game.PlayerBounds.y, game.PlayerBounds.y)), Quaternion.identity);
        //Objective obj = go.GetComponent<Objective>();

    }

    public void EnterStage()
    {
        SpawnObstacles();
        InvokeRepeating("SpawnPowerups", PowerupSpawnDelay, PowerupSpawnDelay);
        Invoke("SpawnObjective", objectiveSpawnDelay);
    }

    public void EndStage()
    {

        //stop invoke repeating calls

        CancelInvoke("SpawnAsteroids");
        CancelInvoke("SpawnFracht");
        CancelInvoke("SpawnMesser");
        CancelInvoke("SpawnPowerups");
        CancelInvoke("SpawnObjective");
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

    public StageResult GetStageResult()
    {
        return result;
    }

    public int GetObjectiveCounter()
    {
        return objectiveCounter;
    }

    public void ResetObjectiveCounter()
    {
        objectiveCounter = 0;
    }
}
