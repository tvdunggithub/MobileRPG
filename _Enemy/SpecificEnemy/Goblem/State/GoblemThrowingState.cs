using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoblemThrowingState : EnemyThrowingState
{
    private Goblem goblem;
    private Color c1 = Color.red;
    private Vector3[] vector3 = { Vector3.zero, Vector3.zero };
    private Vector2 playerPosition;
    private Vector2 goblemProjectilePosition;

    public GoblemThrowingState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyRangedData throwingData, Goblem goblem) : base(enemy, stateMachine, animBoolName, throwingData)
    {
        this.goblem = goblem;
    }

    public override void Enter()
    {
        base.Enter();
        DrawRedLaze();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if(goblem.Player == null)
        {
            goblem.StateMachine.ChangeState(goblem.IdleState);
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
        GameObject projectile = GameObject.Instantiate(throwingData.projectilePrefab, goblem.ProjectileTransform.position, Quaternion.identity, goblem.transform);
        GameObject.Destroy(projectile, 4);
        RemoveLaze();
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        StateMachine.ChangeState(goblem.PlayerDetectedState);
    }

    public void DrawRedLaze()
    {
        goblem.LineRenderer.startColor = c1;
        goblem.LineRenderer.endColor = c1;
        vector3[0] = goblem.ProjectileTransform.position;
        vector3[1] = goblem.Player.transform.position;
        playerPosition.x = goblem.Player.transform.position.x;
        playerPosition.y = goblem.Player.transform.position.y;
        goblemProjectilePosition.x = goblem.ProjectileTransform.position.x;
        goblemProjectilePosition.y = goblem.ProjectileTransform.position.y;
        goblem.LineRenderer.SetPositions(vector3);
        goblem.ShootDirection =  playerPosition - goblemProjectilePosition;
        goblem.ShootDirection.Normalize();
    }

    public void RemoveLaze()
    {
        vector3[0] = Vector3.zero;
        vector3[1] = Vector3.zero;
        goblem.LineRenderer.SetPositions(vector3);
    }
    
}
