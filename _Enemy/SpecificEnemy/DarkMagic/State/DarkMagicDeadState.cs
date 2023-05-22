using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicDeadState : EnemyDeadState
{
    public DarkMagicDeadState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName) : base(enemy, stateMachine, animBoolName)
    {
    }
}
