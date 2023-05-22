using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightBorneMeleeAttackState : EnemyMeleeAttackState
{
    private D_EnemyMeleeAttack meleeAttackData;
    private NightBorne nightBorne;

    public NightBorneMeleeAttackState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyMeleeAttack meleeAttackData, NightBorne nightBorne) : base(enemy, stateMachine, animBoolName, meleeAttackData)
    {
        this.nightBorne = nightBorne;
        this.meleeAttackData = meleeAttackData;
    }

    public override void Enter()
    {
        base.Enter();
        if(!nightBorne.CheckPlayerInAttackRange())
            nightBorne.StateMachine.ChangeState(nightBorne.MoveState);

    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();  
        nightBorne.AttackPlayer();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        if(nightBorne.CheckPlayerInAttackRange())
        {
            WaitAfterAttack();
        }else
            nightBorne.StateMachine.ChangeState(nightBorne.MoveState);
    }

    public void WaitAfterAttack()
    {
        nightBorne.StartCoroutine(WaitAfterAttackIE());
    }

    public IEnumerator WaitAfterAttackIE()
    {
        nightBorne.StateMachine.ChangeState(nightBorne.IdleState);
        nightBorne.CanAttack = false;
        yield return new WaitForSeconds(meleeAttackData.AttackCooldown);
        nightBorne.CanAttack = true;
    }


}
