using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyThrowingState : EnemyAttackState
{
    protected D_EnemyRangedData throwingData;
    public EnemyThrowingState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyRangedData throwingData) : base(enemy, stateMachine, animBoolName)
    {
        this.throwingData = throwingData;
    }
}
