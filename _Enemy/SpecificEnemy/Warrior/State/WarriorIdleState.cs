using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorIdleState : EnemyIdleState
{
    private Warrior _warrior;
    public WarriorIdleState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyIdle idleData, Warrior warrior) : base(enemy, stateMachine, animBoolName, idleData)
    {
        this._warrior = warrior;
    }

    public override void Enter()
    {
        base.Enter();
        _warrior.SetVelocity(Vector2.zero);
        if(!_warrior.CheckPlayerInMinAggroRange())
            _warrior.StartCoroutineChangeStateAndFlip(_idleData.TimeToFlip, _warrior.WalkState);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(_warrior.CheckPlayerInMinAggroRange())
            _warrior.StateMachine.ChangeState(_warrior.RunState);
        if(_warrior.CheckPlayerInAttackRange())
            _warrior.StateMachine.ChangeState(_warrior.MeleeAttackState);
    }

}
