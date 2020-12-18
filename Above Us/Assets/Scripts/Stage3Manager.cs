using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage3Manager : MonoBehaviour, StageInterface
{
    // Start is called before the first frame update
    public const float speedUpgradeModifier = 0.75f;

    //Obstacles
    public float asteroidDelay = 1f;
    public float asteroidRepeat = 1f;
    public int asteroidAmountMin = 2;
    public int asteroidAmountMax = 4;
    public float asteroidMovementXmin = -0.25f;
    public float asteroidMovementXmax = 0.25f;
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
    public float frachtMovementXmin = -0.25f;
    public float frachtMovementXmax = 0.25f;
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
    public float messerMovementXmin = -0.25f;
    public float messerMovementXmax = 0.25f;
    public float messerMovementYmin = -0.25f;
    public float messerMovementYmax = 0.25f;
    public float messerSpeedMin = 5f;
    public float messerSpeedMax = 15f;
    public float messerScaleMin = 0.25f;
    public float messerScaleMax = 1f;

    public int objectiveLimit = 15;
    public float objectiveSpawnDelay = 5f;

    public float PowerupSpawnDelay = 5f;

    private const float constantMovement = -1f;

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

    public void SpawnAsteroids()
    {
        GameObject asteroid = Obstacles[0];
        int asteroidAmount = Random.Range(asteroidAmountMin, asteroidAmountMax);
        for (int i = 0; i < asteroidAmount; i++)
        {
            GameObject ago = Instantiate(asteroid, spawnPoint1(), Quaternion.identity);
            Asteroid a = ago.GetComponent<Asteroid>();
            a.SetMovement(new Vector2(constantMovement, Random.Range(asteroidMovementYmin, asteroidMovementYmax)));
            float speed = Random.Range(asteroidSpeedMin, asteroidSpeedMax);
            if (game.HasSpeedUpgrade())
            {
                speed *= speedUpgradeModifier;
            }
            a.SetSpeed(speed);
            float scaleAmount = Random.Range(asteroidScaleMin, asteroidScaleMax);
            a.transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);
        }

        int asteroidAmount2 = Random.Range(asteroidAmountMin, asteroidAmountMax);
        for (int i = 0; i < asteroidAmount; i++)
        {
            GameObject ago = Instantiate(asteroid, spawnPoint2(), Quaternion.identity);
            Asteroid a = ago.GetComponent<Asteroid>();
            a.SetMovement(new Vector2(Random.Range(asteroidMovementXmin, asteroidMovementXmax), constantMovement));
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
            GameObject ago = Instantiate(fracht, spawnPoint1(), Quaternion.identity);
            Asteroid a = ago.GetComponent<Asteroid>();
            a.SetMovement(new Vector2(constantMovement, Random.Range(frachtMovementYmin, frachtMovementYmax)));
            float speed = Random.Range(frachtSpeedMin, frachtSpeedMax);
            if (game.HasSpeedUpgrade())
            {
                speed *= speedUpgradeModifier;
            }
            a.SetSpeed(speed);
            float scaleAmount = Random.Range(frachtScaleMin, frachtScaleMax);
            a.transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);
        }
        
        int frachtAmount2 = Random.Range(frachtAmountMin, frachtAmountMax);
        for (int i = 0; i < frachtAmount; i++)
        {
            GameObject ago = Instantiate(fracht, spawnPoint2(), Quaternion.identity);
            Asteroid a = ago.GetComponent<Asteroid>();
            a.SetMovement(new Vector2(Random.Range(frachtMovementXmin, frachtMovementXmax), constantMovement));
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
            GameObject ago = Instantiate(messer, spawnPoint1(), Quaternion.identity);
            Asteroid a = ago.GetComponent<Asteroid>();
            a.SetMovement(new Vector2(constantMovement, Random.Range(messerMovementYmin, messerMovementYmax)));
            float speed = Random.Range(messerSpeedMin, messerSpeedMax);
            if (game.HasSpeedUpgrade())
            {
                speed *= speedUpgradeModifier;
            }
            a.SetSpeed(speed);
            float scaleAmount = Random.Range(messerScaleMin, messerScaleMax);
            a.transform.localScale += new Vector3(scaleAmount, scaleAmount, scaleAmount);
        }
        
        int messerAmount2 = Random.Range(messerAmountMin, messerAmountMax);
        for (int i = 0; i < messerAmount; i++)
        {
            GameObject ago = Instantiate(messer, spawnPoint2(), Quaternion.identity);
            Asteroid a = ago.GetComponent<Asteroid>();
            a.SetMovement(new Vector2(Random.Range(messerMovementXmin, messerMovementXmax), constantMovement));
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

    private Vector3 spawnPoint1()
    {
        return new Vector3(game.ScreenBounds.x * spawnOffset, Random.Range(-game.ScreenBounds.y, game.ScreenBounds.y));
    }

    private Vector3 spawnPoint2()
    {
        return new Vector3(Random.Range(-game.ScreenBounds.x, game.ScreenBounds.x), game.ScreenBounds.y * spawnOffset);
    }


    public void SpawnObstacles()
    {
        InvokeRepeating("SpawnAsteroids", asteroidDelay, asteroidRepeat);
        InvokeRepeating("SpawnFracht", frachtDelay, frachtRepeat);
        InvokeRepeating("SpawnMesser", messerDelay, messerRepeat);
    }



    public void SpawnPowerups()
    {
        GameObject go = Instantiate(Powerups[Random.Range(0, Powerups.Length)], spawnPoint1(), Quaternion.identity);
        PowerupAbstract pa = go.GetComponent<PowerupAbstract>();
        pa.SetDirection(new Vector2(-1, 0));

        GameObject go2 = Instantiate(Powerups[Random.Range(0, Powerups.Length)], spawnPoint2(), Quaternion.identity);
        PowerupAbstract pa2 = go2.GetComponent<PowerupAbstract>();
        pa2.SetDirection(new Vector2(0, -1));


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

    public int GetObjectiveLimit()
    {
        return objectiveLimit;
    }
}
