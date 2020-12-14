﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StageFactory
{
    public static Stage1Manager CreateStage1Manager(GameObject parent, GameObject asteroid, GameObject Objective, GameObject[] Powerups)
    {
        Stage1Manager stage1Manager = parent.AddComponent<Stage1Manager>();
        stage1Manager.SetAsteroid(asteroid);
        stage1Manager.SetObjective(Objective);
        stage1Manager.SetPowerups(Powerups);
        return stage1Manager;
    }




}

