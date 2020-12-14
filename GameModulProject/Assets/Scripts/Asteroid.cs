﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Asteroid : MonoBehaviour
{


    private static int SBRemovalMultiplier = 3;



    //only 1 Sprite so far
    //public Sprite[] sprites;

    //private SpriteRenderer spr;
    private float speed;
    private Vector2 movement;
    private Rigidbody2D rb;
    private Vector3 scale;
    private GameManager game;


    //public static Asteroid Create()
    //{

    //    GameObject newobj = Instantiate(this.GameObject) as GameObject;

    //    return this;
    //}


    // Start is called before the first frame update
    void Start()
    {
        game = GameManager.Instance;
        rb = GetComponent<Rigidbody2D>();
        //spr = GetComponent<SpriteRenderer>();
        //if (Random.value >= 0.5)
        //{
        //    spr.flipX = true;
        //}
        //if (Random.value >= 0.5)
        //{
        //    spr.flipY = true;
        //}

        transform.Rotate(0.0f, 0.0f, Random.Range(0.0f, 360.0f));
    }


    // Update is called once per frame
    void Update()
    {

       


    }


    private void FixedUpdate()
    {
        rb.AddForce(movement * speed);
        if(transform.position.x < -game.ScreenBounds.x * SBRemovalMultiplier ||
            transform.position.x > game.ScreenBounds.x * SBRemovalMultiplier ||
            transform.position.y < -game.ScreenBounds.y * SBRemovalMultiplier ||
            transform.position.y > game.ScreenBounds.y * SBRemovalMultiplier)
        {
            Destroy(this.gameObject);
        }
    }
    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }

    public void SetMovement(Vector2 movement)
    {
        this.movement = movement;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.GetComponent<PlayerController>().GetHit();
    }



}
