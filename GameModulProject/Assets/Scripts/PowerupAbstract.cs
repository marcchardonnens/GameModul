using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupAbstract : MonoBehaviour
{
    private const float speed = 0.5f;
    protected PlayerController pc;
    public Vector2 direction;
    

    private void Awake()
    {
        pc = GameManager.Instance.player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Activate();
        Destroy(this.gameObject);
    }

    private void Update()
    {
        GetComponent<Rigidbody2D>().AddForce(new Vector2(-1, 0) * speed);
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }


    public abstract void Activate();


}
