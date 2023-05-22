using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanWalkState : EnemyMoveState
{
    private Shaman _shaman;

    public ShamanWalkState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyMove moveData, Shaman shaman) : base(enemy, stateMachine, animBoolName, moveData)
    {
        this._shaman = shaman;
    }
}
