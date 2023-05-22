using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneIdleState : EnemyIdleState
{
    private NightBorne nightBorne;
    public NightBorneIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyIdle idleData, NightBorne nightBorne) : base(enemy, stateMachine, animBoolName, idleData)
    {
        this.nightBorne = nightBorne;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(nightBorne.CheckPlayerInMinAggroRange() && !nightBorne.CheckPlayerInAttackRange())
            nightBorne.StateMachine.ChangeState(nightBorne.MoveState);
        if(nightBorne.CheckPlayerInAttackRange() && nightBorne.CanAttack) 
            StateMachine.ChangeState(nightBorne.MeleeAttackState);
    }
}
