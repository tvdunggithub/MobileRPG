using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackState : EnemyAttackState
{
    private D_EnemyMeleeAttack _meleeAttackData;
    public EnemyMeleeAttackState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyMeleeAttack meleeAttackData) : base(enemy, stateMachine, animBoolName)
    {
        this._meleeAttackData = meleeAttackData;
    }

    public override void Enter()
    {
        base.Enter();
    }

}
