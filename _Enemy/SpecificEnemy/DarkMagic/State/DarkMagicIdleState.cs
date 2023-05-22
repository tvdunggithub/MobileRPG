using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicIdleState : EnemyIdleState
{
    private DarkMagic _darkMagic;
    public DarkMagicIdleState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyIdle idleData, DarkMagic darkMagic) : base(enemy, stateMachine, animBoolName, idleData)
    {
        this._darkMagic = darkMagic;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        ChangeStateIfDetected(_darkMagic.PlayerDetectedState);
    }
}
