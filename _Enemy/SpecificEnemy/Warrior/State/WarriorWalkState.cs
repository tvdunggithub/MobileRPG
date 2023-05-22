using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorWalkState : EnemyMoveState
{
    private Warrior warrior;
    public WarriorWalkState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyMove moveData, Warrior warrior) : base(enemy, stateMachine, animBoolName, moveData)
    {
        this.warrior = warrior;
    }

    public override void Enter()
    {
        base.Enter();
        warrior.StartCoroutineChangeState(2f, warrior.IdleState);
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(warrior.CheckPlayerInMinAggroRange())
        {
            warrior.StateMachine.ChangeState(warrior.RunState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
        warrior.SetVelocity(moveData.moveSpeed * warrior.AliveGO.transform.right);
    }
}
