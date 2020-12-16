using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShield : PowerupAbstract
{
    public AudioClip Sound;

    public override void Activate()
    {
        pc.PowerUpShield();
        AudioManager.Instance.PlaySound(Sound);
    }
}
