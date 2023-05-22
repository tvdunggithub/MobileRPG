using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneDeadState : EnemyDeadState
{
    private NightBorne _nightBorne;
    public NightBorneDeadState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName,  NightBorne nightBorne) : base(enemy, stateMachine, animBoolName)
    {
        this._nightBorne = nightBorne;
    }
}
