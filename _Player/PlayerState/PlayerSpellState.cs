using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpellState : PlayerState
{
    public PlayerSpellState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, int animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        CanChangeState = false;
        _player.SetVelocity(Vector2.zero);
    }

    public override void Exit()
    {
        base.Exit();
    }


    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
    }

}
