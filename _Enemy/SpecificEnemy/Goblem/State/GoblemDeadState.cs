using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblemDeadState : EnemyDeadState
{
    private Goblem _goblem;

    public GoblemDeadState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, Goblem goblem) : base(enemy, stateMachine, animBoolName)
    {
        this._goblem = goblem;
    }


    
}
