using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected Enemy _enemy;
    protected EnemyStateMachine StateMachine;
    protected int _animBoolName;
    public bool IsAnimationFinished;
    protected float _xPositionCompare;
    protected float _yPositionCompare;
    protected Vector2 _moveDirection;
    public bool CanChangeState;
    public bool IsBlockDrection;

    
    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName)
    {
        this._enemy = enemy;
        this.StateMachine = stateMachine;
        this._animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        _enemy.Anim.SetBool(_animBoolName, true);
        CanChangeState = true;
    }

    public virtual void Exit()
    {
        _enemy.Anim.SetBool(_animBoolName, false);
    }

    public virtual void LogicUpdate()
    {
        ComparePlayeryPosition();
    }

    public virtual void PhysicUpdate()
    {

    }

    public virtual void CheckPlayerPosition()
    {
        if(_enemy.Player != null)
        {
            _moveDirection = _enemy.Player.Transform.position - _enemy.AliveGoTransform.position;
            _moveDirection.Normalize();
        }
    }

    public virtual void ComparePlayerxPosition()
    {
        if(!_enemy.Player)
            return;
        _xPositionCompare = _enemy.Player.Transform.position.x - _enemy.AliveGoTransform.position.x;
    }

    public virtual void ComparePlayeryPosition()
    {
        if(_enemy.Player == null)   
            return;
        _yPositionCompare = _enemy.Player.Transform.position.y - _enemy.AliveGoTransform.position.y;
        if(_yPositionCompare >= 0)
            _enemy.SpriteRenderer.sortingOrder = 1;
        else
            _enemy.SpriteRenderer.sortingOrder = -1;
    }


    public virtual void FlipEnemy()
    {
        if(_xPositionCompare >= 0 && !_enemy.IsFacingRight)
        {
            _enemy.Flip();
            _enemy.IsFacingRight = !_enemy.IsFacingRight;
        }else if (_xPositionCompare < 0 && _enemy.IsFacingRight)
        {
            _enemy.Flip();
            _enemy.IsFacingRight = !_enemy.IsFacingRight;
        }
    }

    public virtual bool IsDeadState()
    {
        return false;
    }

}
