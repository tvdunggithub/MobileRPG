using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneDeadState : EnemyDeadState
{
    private NightBorne nightBorne;
    public NightBorneDeadState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName,  NightBorne nightBorne) : base(enemy, stateMachine, animBoolName)
    {
        this.nightBorne = nightBorne;
    }
}
