using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangedState : EnemyAttackState
{
    protected D_EnemyRangedData _throwingData;
    public EnemyRangedState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyRangedData throwingData) : base(enemy, stateMachine, animBoolName)
    {
        this._throwingData = throwingData;
    }
}
