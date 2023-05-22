using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorWalkState : EnemyMoveState
{
    private Warrior _warrior;
    public WarriorWalkState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyMove moveData, Warrior warrior) : base(enemy, stateMachine, animBoolName, moveData)
    {
        this._warrior = warrior;
    }

    public override void Enter()
    {
        base.Enter();
        _warrior.StartCoroutineChangeState(2f, _warrior.IdleState);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(_warrior.CheckPlayerInMinAggroRange())
        {
            _warrior.StateMachine.ChangeState(_warrior.RunState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        _warrior.SetVelocity(_moveData.MoveSpeed * _warrior.AliveGoTransform.right);
    }
}
