using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPlayerDetectedState : EnemyState
{
    protected D_EnemyPlayerDetected _enemyPlayerDetectedData;
    public EnemyPlayerDetectedState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyPlayerDetected enemyPlayerDetectedData) : base(enemy, stateMachine, animBoolName)
    {
        this._enemyPlayerDetectedData = enemyPlayerDetectedData;
    }

}
