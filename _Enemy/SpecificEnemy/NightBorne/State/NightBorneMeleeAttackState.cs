using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneMeleeAttackState : EnemyMeleeAttackState
{
    private D_EnemyMeleeAttack _meleeAttackData;
    private NightBorne _nightBorne;

    public NightBorneMeleeAttackState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyMeleeAttack meleeAttackData, NightBorne nightBorne) : base(enemy, stateMachine, animBoolName, meleeAttackData)
    {
        this._nightBorne = nightBorne;
        this._meleeAttackData = meleeAttackData;
    }

    public override void Enter()
    {
        base.Enter();
        if(!_nightBorne.CheckPlayerInAttackRange())
            _nightBorne.StateMachine.ChangeState(_nightBorne.MoveState);

    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();  
        _nightBorne.AttackPlayer();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        if(_nightBorne.CheckPlayerInAttackRange())
        {
            WaitAfterAttack();
        }else
            _nightBorne.StateMachine.ChangeState(_nightBorne.MoveState);
    }

    public void WaitAfterAttack()
    {
        _nightBorne.StartCoroutine(WaitAfterAttackIE());
    }

    public IEnumerator WaitAfterAttackIE()
    {
        _nightBorne.StateMachine.ChangeState(_nightBorne.IdleState);
        _nightBorne.CanAttack = false;
        yield return new WaitForSeconds(_meleeAttackData.AttackCooldown);
        _nightBorne.CanAttack = true;
    }


}
