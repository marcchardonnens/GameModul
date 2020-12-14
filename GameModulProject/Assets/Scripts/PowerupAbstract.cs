using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerupAbstract : MonoBehaviour
{
    protected PlayerController pc;
    

    private void Awake()
    {
        pc = GameManager.Instance.player.GetComponent<PlayerController>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Activate();
        Destroy(this.gameObject);
    }


    public abstract void Activate();


}
