using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    public EnemyDeadState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isAnimationFinished = false;
        CanChangeState = false;
        enemy.SetVelocity(Vector2.zero);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(isAnimationFinished)
            enemy.Dead();
    }

    public override bool IsDeadState()
    {
        return true;
    }
}
