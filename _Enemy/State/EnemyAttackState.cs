using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        enemy.SetVelocity(Vector2.zero);
        enemy.Atsm.AttackState = this;
        enemy._attackDetails.Position = enemy.AliveGO.transform.position;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public virtual void TriggerAttack()
    {

    }

    public virtual void FinishAttack()
    {

    }

}
