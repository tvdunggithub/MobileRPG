using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanIdleState : EnemyIdleState
{
    private Shaman shaman;
    private int _turn;
    public ShamanIdleState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyIdle idleData, Shaman shaman) : base(enemy, stateMachine, animBoolName, idleData)
    {
        this.shaman = shaman;
    }

    public override void Enter()
    {
        base.Enter();
        _turn++;
        if(_turn == 5)
            _turn = 1;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(enemy.CheckPlayerInMinAggroRange())
            ChangeState();
    }

    private void ChangeState()
    {
        switch(_turn) 
        {
            case 1:
                shaman.StartCoroutineChangeState(2f, shaman.MagicOneState);
                break;
            case 2:
                shaman.StartCoroutineChangeState(0.2f, shaman.MagicOneState);
                break;
            case 3:
                shaman.StartCoroutineChangeState(2f, shaman.MagicThreeState);
                break;
            case 4:
                shaman.StartCoroutineChangeState(2f, shaman.MagicTwoState);
                break;
        }
    }
}
