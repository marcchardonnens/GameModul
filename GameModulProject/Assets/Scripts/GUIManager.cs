using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{

    public Sprite imgObjectiveCounter;
    public Sprite imgHeart;
    public int fontSize = 30;

    private static GUIManager instance;
    public static GUIManager Instance { get { return instance; }  }

    private GameManager game;
    private GameObject title;
    private GameObject gameStarter;
    private GameObject Background;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
        
    }

    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.Instance;
        title = FindObjectOfType<Title>().gameObject;
        gameStarter = FindObjectOfType<GameStarter>().gameObject;

    }

    // Update is called once per frame
    void Update()
    {
        MoveBackground();
    }

    public void OnGameStart()
    {
        title.gameObject.SetActive(false);
        gameStarter.gameObject.SetActive(false);
    }

    public void OnTitleScreen()
    {
        title.gameObject.SetActive(true);
        gameStarter.gameObject.SetActive(true);
    }


    private void OnGUI()
    {
        GUI.skin.label.fontSize = fontSize;
        GUI.Label(new Rect(10, 10, 40, 40), imgObjectiveCounter.texture);
        int objCounter = 0;
        if(game.CurrentStage != null)
        {
            game.CurrentStage.GetObjectiveCounter();
        }
        GUI.Label(new Rect(40, 10, 140, 40), " X " + objCounter);
        GUI.Label(new Rect(130, 10, 40, 40), imgHeart.texture);
        GUI.Label(new Rect(170, 10, 140, 40), " X " + game.playerController.Health);
    }

    private void MoveBackground()
    {

    }
}
