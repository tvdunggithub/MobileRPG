using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblemIdleState : EnemyIdleState
{
    private Goblem _goblem;
    public GoblemIdleState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyIdle idleData, Goblem goblem) : base(enemy, stateMachine, animBoolName, idleData)
    {
        this._goblem = goblem;
    }

    public override void Enter()
    {
        base.Enter();
        _goblem.IsIdling = true;
        _goblem.StartCoroutineToFlip(_idleData.TimeToFlip);
    }

    public override void Exit()
    {
        base.Exit();
        _goblem.IsIdling = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        ChangeStateIfDetected(_goblem.PlayerDetectedState);
    }

}
