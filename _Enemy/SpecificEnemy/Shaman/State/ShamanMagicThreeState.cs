using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShamanMagicThreeState : EnemyAttackState
{
    private Shaman _shaman;
    private D_ShamanMagicThree _magicThreeData;
    public ShamanMagicThreeState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_ShamanMagicThree _magicThreeData, Shaman shaman) : base(enemy, stateMachine, animBoolName)
    {
        this._shaman = shaman;
        this._magicThreeData = _magicThreeData;
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        GameObject.Instantiate(_shaman.MagicThreePrefab, _shaman.Player.Transform.position, Quaternion.identity, _shaman.Transform);
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        _shaman.StateMachine.ChangeState(_shaman.IdleState);
    }
}
