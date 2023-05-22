using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorMeleeAttackState : EnemyMeleeAttackState
{
    private Warrior _warrior;
    public WarriorMeleeAttackState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyMeleeAttack meleeAttackData, Warrior warrior) : base(enemy, stateMachine, animBoolName, meleeAttackData)
    {
        this._warrior = warrior;
    }

    public override void Enter()
    {
        base.Enter();
        _warrior.SetVelocity(Vector2.zero);
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        _warrior.AttackPlayer();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        _warrior.StateMachine.ChangeState(_warrior.ProtectState);
    }
}
