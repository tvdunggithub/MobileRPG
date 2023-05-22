using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState 
{
    protected Enemy enemy;
    protected EnemyStateMachine StateMachine;
    protected string animBoolName;
    public bool isAnimationFinished;
    protected float xPositionCompare;
    protected float yPositionCompare;
    protected Vector2 moveDirection;
    public bool CanChangeState;
    public bool IsBlockDrection;

    
    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName)
    {
        this.enemy = enemy;
        this.StateMachine = stateMachine;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        enemy.Anim.SetBool(animBoolName, true);
        CanChangeState = true;
    }

    public virtual void Exit()
    {
        enemy.Anim.SetBool(animBoolName, false);
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
        if(enemy.Player != null)
        {
            moveDirection = enemy.Player.transform.position - enemy.AliveGO.transform.position;
            moveDirection.Normalize();
        }
    }

    public virtual void ComparePlayerxPosition()
    {
        if(!enemy.Player)
            return;
        xPositionCompare = enemy.Player.transform.position.x - enemy.AliveGO.transform.position.x;
    }

    public virtual void ComparePlayeryPosition()
    {
        if(enemy.Player == null)   
            return;
        yPositionCompare = enemy.Player.transform.position.y - enemy.AliveGO.transform.position.y;
        if(yPositionCompare >= 0)
            enemy.SpriteRenderer.sortingOrder = 1;
        else
            enemy.SpriteRenderer.sortingOrder = -1;
    }


    public virtual void FlipEnemy()
    {
        if(xPositionCompare >= 0 && !enemy.IsFacingRight)
        {
            enemy.Flip();
            enemy.IsFacingRight = !enemy.IsFacingRight;
        }else if (xPositionCompare < 0 && enemy.IsFacingRight)
        {
            enemy.Flip();
            enemy.IsFacingRight = !enemy.IsFacingRight;
        }
    }

    public virtual bool IsDeadState()
    {
        return false;
    }

}
