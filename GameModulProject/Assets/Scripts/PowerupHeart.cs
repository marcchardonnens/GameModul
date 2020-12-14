using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupHeart : PowerupAbstract
{
    public override void Activate()
    {
        pc.PowerUpHeart();
    }
}
