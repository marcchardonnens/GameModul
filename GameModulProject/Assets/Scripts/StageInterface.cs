using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface StageInterface
{
    void ExecuteStage();
    void SpawnObstacles();
    void SpawnPowerups();
    void SpawnObjective();
    void EnterStage();
    void EndStage();
    bool WinConditionReached();
    void ObjectiveCollected();
    void SetStageResult(StageResult result);
    StageResult GetStageResult();
    int GetObjectiveCounter();
    void ResetObjectiveCounter();

}
public enum StageResult
{
    Default,
    Win,
    Loss
}