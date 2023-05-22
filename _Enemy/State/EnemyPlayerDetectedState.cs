using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetectedState : EnemyState
{
    protected D_EnemyPlayerDetected enemyPlayerDetectedData;
    public EnemyPlayerDetectedState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyPlayerDetected enemyPlayerDetectedData) : base(enemy, stateMachine, animBoolName)
    {
        this.enemyPlayerDetectedData = enemyPlayerDetectedData;
    }

}
