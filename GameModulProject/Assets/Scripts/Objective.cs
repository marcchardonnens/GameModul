using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{

    public Sprite[] sprites;

    private GameManager game;


    private void Awake()
    {
        game = GameManager.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = sprites[Random.Range(0, 3)];
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //count up Objective
        game.CurrentStage.ObjectiveCollected();
        Destroy(this.gameObject);
    }
}
