using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblemThrowingState : EnemyThrowingState
{
    private Goblem _goblem;
    private Color _c1 = Color.red;
    private Vector3[] _vector3 = { Vector3.zero, Vector3.zero };
    private Vector2 _playerPosition;
    private Vector2 _goblemProjectilePosition;

    public GoblemThrowingState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyRangedData throwingData, Goblem goblem) : base(enemy, stateMachine, animBoolName, throwingData)
    {
        this._goblem = goblem;
    }

    public override void Enter()
    {
        base.Enter();
        DrawRedLaze();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(_goblem.Player == null)
        {
            _goblem.StateMachine.ChangeState(_goblem.IdleState);
            RemoveLaze();
        }
        else
        {
            ComparePlayerxPosition();
            FlipEnemy();
        }
    }

    public override void TriggerAttack()
    {
        GameObject projectile = GameObject.Instantiate(_throwingData.ProjectilePrefab, _goblem.ProjectileTransform.position, Quaternion.identity, _goblem.Transform);
        GameObject.Destroy(projectile, 4);
        RemoveLaze();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        StateMachine.ChangeState(_goblem.PlayerDetectedState);
    }

    public void DrawRedLaze()
    {
        _goblem.LineRenderer.startColor = _c1;
        _goblem.LineRenderer.endColor = _c1;
        _vector3[0] = _goblem.ProjectileTransform.position;
        _vector3[1] = _goblem.Player.Transform.position;
        _playerPosition.x = _goblem.Player.Transform.position.x;
        _playerPosition.y = _goblem.Player.Transform.position.y;
        _goblemProjectilePosition.x = _goblem.ProjectileTransform.position.x;
        _goblemProjectilePosition.y = _goblem.ProjectileTransform.position.y;
        _goblem.LineRenderer.SetPositions(_vector3);
        _goblem.ShootDirection =  _playerPosition - _goblemProjectilePosition;
        _goblem.ShootDirection.Normalize();
    }

    public void RemoveLaze()
    {
        _vector3[0] = Vector3.zero;
        _vector3[1] = Vector3.zero;
        _goblem.LineRenderer.SetPositions(_vector3);
    }
    
}
