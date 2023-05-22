using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveState : EnemyState
{
    protected D_EnemyMove _moveData;
    public EnemyMoveState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyMove moveData) : base(enemy, stateMachine, animBoolName)
    {
        this._moveData = moveData;
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();       
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        CheckPlayerPosition();   
    }



}
