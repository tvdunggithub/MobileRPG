using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : PlayerState
{
    public PlayerDeadState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, int animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        CanChangeState = false;
        _player.SetVelocity(Vector2.zero);
        _isAnimationFinished = false;
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(_isAnimationFinished)
        {
            GameObject.Destroy(_player.gameObject);
        }
    }

    public override void Exit()
    {
        base.Exit();
    }


}
