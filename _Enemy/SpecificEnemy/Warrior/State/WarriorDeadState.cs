using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarriorDeadState : EnemyDeadState
{
    public WarriorDeadState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }
}
