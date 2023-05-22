using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblemIdleState : EnemyIdleState
{
    private Goblem goblem;
    public GoblemIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyIdle idleData, Goblem goblem) : base(enemy, stateMachine, animBoolName, idleData)
    {
        this.goblem = goblem;
    }

    public override void Enter()
    {
        base.Enter();
        goblem.IsIdling = true;
        goblem.StartCoroutineToFlip(idleData.timeToFlip);
    }

    public override void Exit()
    {
        base.Exit();
        goblem.IsIdling = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        ChangeStateIfDetected(goblem.PlayerDetectedState);
    }

}
