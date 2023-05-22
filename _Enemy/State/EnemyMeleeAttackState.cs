using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMeleeAttackState : EnemyAttackState
{
    private D_EnemyMeleeAttack meleeAttackData;
    public EnemyMeleeAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyMeleeAttack meleeAttackData) : base(enemy, stateMachine, animBoolName)
    {
        this.meleeAttackData = meleeAttackData;
    }

    public override void Enter()
    {
        base.Enter();
    }

}
