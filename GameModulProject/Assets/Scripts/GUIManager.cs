using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIManager : MonoBehaviour
{

    public Sprite imgObjectiveCounter;
    public Sprite imgHeart;
    public int fontSize = 20;


    private GameManager game;

    private void Awake()
    {
        
    }

    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnGUI()
    {
        GUI.skin.label.fontSize = fontSize;
        GUI.Label(new Rect(10, 10, 40, 40), imgObjectiveCounter.texture);
        GUI.Label(new Rect(40, 10, 140, 40), " X " + GameManager.Instance.CurrentStage.GetObjectiveCounter());
        GUI.Label(new Rect(130, 10, 40, 40), imgHeart.texture);
        GUI.Label(new Rect(170, 10, 140, 40), " X " + game.playerController.Health);
    }
}
