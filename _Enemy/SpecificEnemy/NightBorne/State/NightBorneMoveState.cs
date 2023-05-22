using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneMoveState : EnemyMoveState
{
    private NightBorne nightBorne;

    public NightBorneMoveState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyMove moveData, NightBorne nightBorne) : base(enemy, stateMachine, animBoolName, moveData)
    {
        this.nightBorne = nightBorne;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(nightBorne.CheckPlayerInAttackRange() && nightBorne.CanAttack) 
            StateMachine.ChangeState(nightBorne.MeleeAttackState);
        else if(nightBorne.CheckPlayerInAttackRange() && !nightBorne.CanAttack)
            StateMachine.ChangeState(nightBorne.IdleState);
        if(nightBorne.Player == null)
            nightBorne.StateMachine.ChangeState(nightBorne.IdleState);
        else
        {
            ComparePlayerxPosition();
            FlipEnemy();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        enemy.SetVelocity(moveDirection * moveData.moveSpeed);
    }
}
