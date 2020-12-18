using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StageFactory
{
    public static Stage1Manager CreateStage1Manager(GameObject parent, GameObject[] Obstacles, GameObject Objective, GameObject[] Powerups)
    {
        Stage1Manager stage1Manager = parent.AddComponent<Stage1Manager>();
        stage1Manager.SetObstacles(Obstacles);
        stage1Manager.SetObjective(Objective);
        stage1Manager.SetPowerups(Powerups);
        return stage1Manager;
    }
        public static Stage2Manager CreateStage2Manager(GameObject parent, GameObject[] Obstacles, GameObject Objective, GameObject[] Powerups)
    {
        Stage2Manager stage2Manager = parent.AddComponent<Stage2Manager>();
        stage2Manager.SetObstacles(Obstacles);
        stage2Manager.SetObjective(Objective);
        stage2Manager.SetPowerups(Powerups);
        return stage2Manager;
    }
    public static Stage3Manager CreateStage3Manager(GameObject parent, GameObject[] Obstacles, GameObject Objective, GameObject[] Powerups)
    {
        Stage3Manager stage3Manager = parent.AddComponent<Stage3Manager>();
        stage3Manager.SetObstacles(Obstacles);
        stage3Manager.SetObjective(Objective);
        stage3Manager.SetPowerups(Powerups);
        return stage3Manager;
    }

    public static IntermissionStage CreateIntermissionStage(GameObject parent, GameObject shieldUpgrade, GameObject speedUpgrade, GameObject Alien)
    {
        IntermissionStage stage = parent.AddComponent<IntermissionStage>();
        stage.SetSpeedUpgrade(speedUpgrade);
        stage.SetShieldUpgrade(shieldUpgrade);
        stage.SetAlien(Alien);

        return stage;
    }




}

