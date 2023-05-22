using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneMoveState : EnemyMoveState
{
    private NightBorne _nightBorne;

    public NightBorneMoveState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyMove moveData, NightBorne nightBorne) : base(enemy, stateMachine, animBoolName, moveData)
    {
        this._nightBorne = nightBorne;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(_nightBorne.CheckPlayerInAttackRange() && _nightBorne.CanAttack) 
            StateMachine.ChangeState(_nightBorne.MeleeAttackState);
        else if(_nightBorne.CheckPlayerInAttackRange() && !_nightBorne.CanAttack)
            StateMachine.ChangeState(_nightBorne.IdleState);
        if(_nightBorne.Player == null)
            _nightBorne.StateMachine.ChangeState(_nightBorne.IdleState);
        else
        {
            ComparePlayerxPosition();
            FlipEnemy();
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        _enemy.SetVelocity(_moveDirection * _moveData.MoveSpeed);
    }
}
