using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHeart : PowerupAbstract
{
    public AudioClip Sound;
    public override void Activate()
    {
        pc.PowerUpHeart();
        AudioManager.Instance.PlaySound(Sound);
    }
}
