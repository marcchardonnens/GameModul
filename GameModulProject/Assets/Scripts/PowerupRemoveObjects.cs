using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupRemoveObjects : PowerupAbstract
{
    public override void Activate()
    {
        pc.PowerUpRemoveObjects();
    }
}
