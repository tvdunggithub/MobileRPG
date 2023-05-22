using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorRunState : EnemyMoveState
{
    private Warrior _warrior;
    public WarriorRunState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyMove moveData, Warrior warrior) : base(enemy, stateMachine, animBoolName, moveData)
    {
        this._warrior = warrior;
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
        if(_warrior.CheckPlayerInAttackRange())
            ChangeAttackState();
        
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        _warrior.SetVelocity(_moveDirection * _moveData.MoveSpeed);
    }

    private void ChangeAttackState()
    {
        CanChangeState = true;
        _warrior.StateMachine.ChangeState(_warrior.MeleeAttackState);
    }
}
