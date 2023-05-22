using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblemDeadState : EnemyDeadState
{
    private Goblem goblem;

    public GoblemDeadState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, Goblem goblem) : base(enemy, stateMachine, animBoolName)
    {
        this.goblem = goblem;
    }


    
}
