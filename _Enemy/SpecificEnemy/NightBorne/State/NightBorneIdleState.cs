using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneIdleState : EnemyIdleState
{
    private NightBorne _nightBorne;
    public NightBorneIdleState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyIdle idleData, NightBorne nightBorne) : base(enemy, stateMachine, animBoolName, idleData)
    {
        this._nightBorne = nightBorne;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(_nightBorne.CheckPlayerInMinAggroRange() && !_nightBorne.CheckPlayerInAttackRange())
            _nightBorne.StateMachine.ChangeState(_nightBorne.MoveState);
        if(_nightBorne.CheckPlayerInAttackRange() && _nightBorne.CanAttack) 
            StateMachine.ChangeState(_nightBorne.MeleeAttackState);
    }
}
