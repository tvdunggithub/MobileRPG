using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIdleState : EnemyState
{
    protected D_EnemyIdle idleData;
    
    public EnemyIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyIdle idleData) : base(enemy, stateMachine, animBoolName)
    {
        this.idleData = idleData;
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(Vector2.zero);
    }

    protected virtual void ChangeStateIfDetected(EnemyState state)
    {
        if(enemy.CheckPlayerInMinAggroRange())
            StateMachine.ChangeState(state);  
    }
}
