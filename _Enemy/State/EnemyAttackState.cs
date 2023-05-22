using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackState : EnemyState
{
    public EnemyAttackState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _enemy.SetVelocity(Vector2.zero);
        _enemy.Atsm.AttackState = this;
        _enemy._attackDetails.Position = _enemy.AliveGoTransform.position;
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
