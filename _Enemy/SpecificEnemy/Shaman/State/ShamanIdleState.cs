using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanIdleState : EnemyIdleState
{
    private Shaman _shaman;
    private int _turn;
    public ShamanIdleState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyIdle idleData, Shaman shaman) : base(enemy, stateMachine, animBoolName, idleData)
    {
        this._shaman = shaman;
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
        if(_enemy.CheckPlayerInMinAggroRange())
            ChangeState();
    }

    private void ChangeState()
    {
        switch(_turn) 
        {
            case 1:
                _shaman.StartCoroutineChangeState(2f, _shaman.MagicOneState);
                break;
            case 2:
                _shaman.StartCoroutineChangeState(0.2f, _shaman.MagicOneState);
                break;
            case 3:
                _shaman.StartCoroutineChangeState(2f, _shaman.MagicThreeState);
                break;
            case 4:
                _shaman.StartCoroutineChangeState(2f, _shaman.MagicTwoState);
                break;
        }
    }
}
