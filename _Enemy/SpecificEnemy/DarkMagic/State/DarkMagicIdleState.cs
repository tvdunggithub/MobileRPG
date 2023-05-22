using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicIdleState : EnemyIdleState
{
    private DarkMagic darkMagic;
    public DarkMagicIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyIdle idleData, DarkMagic darkMagic) : base(enemy, stateMachine, animBoolName, idleData)
    {
        this.darkMagic = darkMagic;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        ChangeStateIfDetected(darkMagic.PlayerDetectedState);
    }
}
