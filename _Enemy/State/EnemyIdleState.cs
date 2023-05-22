using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected D_EnemyIdle _idleData;
    
    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyIdle idleData) : base(enemy, stateMachine, animBoolName)
    {
        this._idleData = idleData;
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.SetVelocity(Vector2.zero);
    }

    protected virtual void ChangeStateIfDetected(EnemyState state)
    {
        if(_enemy.CheckPlayerInMinAggroRange())
            StateMachine.ChangeState(state);  
    }
}
