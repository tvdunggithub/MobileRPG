using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState 
{
    protected Player _player;
    protected PlayerStateMachine _stateMachine;
    protected PlayerData _playerData;
    public bool _isAnimationFinished;
    protected Vector2 _input;
    private int _animBoolName;
    public bool CanChangeState;


    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, int animBoolName)
    {
        this._player = player;
        this._stateMachine = stateMachine;
        this._playerData = playerData;
        this._animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        _player.Anim.SetBool(_animBoolName, true);
        
    }

    public virtual void Exit()
    {
        _player.Anim.SetBool(_animBoolName, false);
        
    }

    public virtual void LogicUpdate()
    {
        _input = _player.PlayerInput.MoveInput;
    }

    public virtual void PhysicsUpdate()
    {
        
    }

}
