using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanDeadState : EnemyDeadState
{
    public ShamanDeadState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
}
