using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ShamanMagicTwoState : EnemyAttackState
{
    private Shaman shaman;
    private D_ShamanMagicTwo _magicTwoData;
    public ShamanMagicTwoState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_ShamanMagicTwo _magicTwoData, Shaman shaman) : base(enemy, stateMachine, animBoolName)
    {
        this.shaman = shaman;
        this._magicTwoData = _magicTwoData;
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        GameObject.Instantiate(shaman.SummonEnemy, GetRandomPosition(), Quaternion.identity);
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        shaman.StateMachine.ChangeState(shaman.IdleState);
    }

    private Vector3 GetRandomPosition()
    {
        System.Random rnd = new System.Random();
        return new Vector3(rnd.Next(50, 55), rnd.Next(-4, 4), 0);
    }

}
