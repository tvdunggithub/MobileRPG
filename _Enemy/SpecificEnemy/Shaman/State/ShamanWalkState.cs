using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanWalkState : EnemyMoveState
{
    private Shaman shaman;

    public ShamanWalkState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyMove moveData, Shaman shaman) : base(enemy, stateMachine, animBoolName, moveData)
    {
        this.shaman = shaman;
    }
}
