using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorIdleState : EnemyIdleState
{
    private Warrior warrior;
    public WarriorIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyIdle idleData, Warrior warrior) : base(enemy, stateMachine, animBoolName, idleData)
    {
        this.warrior = warrior;
    }

    public override void Enter()
    {
        base.Enter();
        warrior.SetVelocity(Vector2.zero);
        if(!warrior.CheckPlayerInMinAggroRange())
            warrior.StartCoroutineChangeStateAndFlip(idleData.timeToFlip, warrior.WalkState);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(warrior.CheckPlayerInMinAggroRange())
            warrior.StateMachine.ChangeState(warrior.RunState);
        if(warrior.CheckPlayerInAttackRange())
            warrior.StateMachine.ChangeState(warrior.MeleeAttackState);
    }

}
