using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorRunState : EnemyMoveState
{
    private Warrior warrior;
    public WarriorRunState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyMove moveData, Warrior warrior) : base(enemy, stateMachine, animBoolName, moveData)
    {
        this.warrior = warrior;
    }

    public override void Enter()
    {
        base.Enter();
        CanChangeState = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        ComparePlayerxPosition();
        FlipEnemy();
        if(warrior.CheckPlayerInAttackRange())
            ChangeAttackState();
        
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        warrior.SetVelocity(moveDirection * moveData.moveSpeed);
    }

    private void ChangeAttackState()
    {
        CanChangeState = true;
        warrior.StateMachine.ChangeState(warrior.MeleeAttackState);
    }
}
