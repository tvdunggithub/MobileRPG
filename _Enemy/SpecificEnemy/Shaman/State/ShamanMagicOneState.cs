using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanMagicOneState : EnemyAttackState
{
    private Shaman _shaman;
    private D_ShamanMagicOne _magicOneData;
    private int _turn;
    public ShamanMagicOneState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_ShamanMagicOne magicOneData, Shaman shaman) : base(enemy, stateMachine, animBoolName)
    {
        this._shaman = shaman;
        this._magicOneData = magicOneData;
    }

    public override void Enter()
    {
        base.Enter();
        if(_turn == 1)
            _shaman.ResetColor();
        foreach(GameObject laze in _shaman.LazeArray)
        {
            laze.SetActive(true);
        }

    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        foreach(GameObject laze in _shaman.LazeArray)
        {
            laze.GetComponent<LineController>().IsActive = true;
        }
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        foreach(GameObject laze in _shaman.LazeArray)
        {
            laze.SetActive(false);
        }
        if(_turn == 0)
        {
            //reset color, flash and change idle state
            _turn++;
            _shaman.ChangeColorBeforeFlashCO();
            //Debug.Log("vo day");
        }else
        {
            _turn = 0;
            _shaman.StateMachine.ChangeState(_shaman.IdleState);
        }
    }
}
