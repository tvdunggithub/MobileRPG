using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerState
{
    public PlayerDashState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, int animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        CanChangeState = false;
        _player.Dash();
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
        SetDashVelocity(_player.PlayerInput.MoveInput);
        if(!_player.IsDashing)
        {
            CanChangeState = true;
            _stateMachine.ChangeState(_player.IdleState);
        }
    }

    private void SetDashVelocity(Vector2 input)
    {
        if(input == Vector2.zero)
        {
            if(_player.IsDashing && _player.IsPlayerFacingRight)
                _player.SetVelocity(Vector2.right * _player.PlayerData.DashSpeed);
            if(_player.IsDashing && !_player.IsPlayerFacingRight)
                _player.SetVelocity(Vector2.left * _player.PlayerData.DashSpeed);
        }
        else if(_player.IsDashing)
        {
            _player.SetVelocity(input * _player.PlayerData.DashSpeed);
        }
        
    }

}
