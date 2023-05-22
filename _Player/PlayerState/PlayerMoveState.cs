using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerState
{
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, int animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        CanChangeState = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        _player.CheckIfShouldFlip(_input);
        if(_input == Vector2.zero)
            _stateMachine.ChangeState(_player.IdleState);
    }

    public override void PhysicsUpdate()
    {
        _player.SetVelocity(_input);
        base.PhysicsUpdate();
    }
}
