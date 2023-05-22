using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeadState : EnemyState
{
    public EnemyDeadState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        IsAnimationFinished = false;
        CanChangeState = false;
        _enemy.SetVelocity(Vector2.zero);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(IsAnimationFinished)
            _enemy.Dead();
    }

    public override bool IsDeadState()
    {
        return true;
    }
}
