using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowingState : EnemyAttackState
{
    protected D_EnemyRangedData _throwingData;
    public EnemyThrowingState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyRangedData throwingData) : base(enemy, stateMachine, animBoolName)
    {
        this._throwingData = throwingData;
    }
}
