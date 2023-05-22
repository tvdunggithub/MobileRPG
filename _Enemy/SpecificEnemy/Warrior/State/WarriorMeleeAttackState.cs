using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMeleeAttackState : EnemyMeleeAttackState
{
    private Warrior warrior;
    public WarriorMeleeAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyMeleeAttack meleeAttackData, Warrior warrior) : base(enemy, stateMachine, animBoolName, meleeAttackData)
    {
        this.warrior = warrior;
    }

    public override void Enter()
    {
        base.Enter();
        warrior.SetVelocity(Vector2.zero);
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        warrior.AttackPlayer();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        warrior.StateMachine.ChangeState(warrior.ProtectState);
    }
}
