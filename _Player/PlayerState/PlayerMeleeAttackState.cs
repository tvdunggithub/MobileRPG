using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttackState : PlayerState
{
    protected AttackAmount _attackAmount;
    public PlayerMeleeAttackState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, int animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        _player.SetVelocity(Vector2.zero);
        CanChangeState = true;
        _player.Anim.SetInteger("attackAmount", (int)_attackAmount);
        _attackAmount++;
        _player.MeleeAttackDetails.Position = _player.Transform.position;
        if((int)_attackAmount > 2)
            _attackAmount = 0;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}

public enum AttackAmount
{
    first,
    seconrd,
    third
}
    

