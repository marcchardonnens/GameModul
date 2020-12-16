using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRemoveObjects : PowerupAbstract
{
    public AudioClip Sound;
    public override void Activate()
    {
        pc.PowerUpRemoveObjects();
        AudioManager.Instance.PlaySound(Sound);
    }
}
