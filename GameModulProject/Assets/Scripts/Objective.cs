using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{

    public AudioClip Sound;

    private GameManager game;


    private void Awake()
    {
        game = GameManager.Instance;
    }

    // Start is called before the first frame update
    void Start()
    {
        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
        GetComponent<Animator>().SetInteger("nColorVariant", Random.Range(0, 4));
        transform.localScale = new Vector3(2, 2, 2);
    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //count up Objective
        game.CurrentStage.ObjectiveCollected();
        AudioManager.Instance.PlaySound(Sound);
        Destroy(this.gameObject);
    }
}
