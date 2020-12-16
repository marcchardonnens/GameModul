using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerupShield : PowerupAbstract
{

    public override void Activate()
    {
        pc.PowerUpShield();
    }
}
