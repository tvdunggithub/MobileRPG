using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanMagicThreeState : EnemyAttackState
{
    private Shaman shaman;
    private D_ShamanMagicThree _magicThreeData;
    public ShamanMagicThreeState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_ShamanMagicThree _magicThreeData, Shaman shaman) : base(enemy, stateMachine, animBoolName)
    {
        this.shaman = shaman;
        this._magicThreeData = _magicThreeData;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        GameObject.Instantiate(shaman.MagicThreePrefab, shaman.Player.transform.position, Quaternion.identity, shaman.transform);
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        shaman.StateMachine.ChangeState(shaman.IdleState);
    }
}
