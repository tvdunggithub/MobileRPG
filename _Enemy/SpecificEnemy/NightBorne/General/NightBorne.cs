using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Goblem
public class NightBorne : Enemy
{

    [SerializeField]
    private D_EnemyMove _moveData;
    [SerializeField]
    private D_EnemyIdle _idleData;
    [SerializeField]
    private D_EnemyMeleeAttack _meleeAttackData;
    [SerializeField]
    private Transform _meleeAttackTranform;


    public NightBorneMoveState MoveState { get; private set; }
    public NightBorneIdleState IdleState { get; private set; }
    public NightBorneMeleeAttackState MeleeAttackState { get; private set; }

    public override void Start() 
    {
        base.Start();
        MoveState = new NightBorneMoveState(this, StateMachine, "move", _moveData, this);
        IdleState = new NightBorneIdleState(this, StateMachine, "idle", _idleData, this);
        MeleeAttackState = new NightBorneMeleeAttackState(this, StateMachine, "meleeAttack", _meleeAttackData, this);
        DeadState = new NightBorneDeadState(this, StateMachine, "dead", this);

        StateMachine.Initialize(IdleState);
        Flip();
        _attackDetails.DamageAmount = _meleeAttackData.AttackDamage;
    }

    public virtual bool CheckPlayerInAttackRange()
    {
        return Physics2D.OverlapCircle(AliveGO.transform.position, _meleeAttackData.AttackRange, EnemyBaseData.whatIsPlayer);
    }

    public void AttackPlayer()
    {
        Collider2D detectedObject = Physics2D.OverlapCircle(_meleeAttackTranform.position, _meleeAttackData.AttackRadius, EnemyBaseData.whatIsPlayer);
        if(detectedObject != null)
        {
            PlayerDamageable playerDamageable = detectedObject.GetComponent<PlayerDamageable>();
            playerDamageable.Damage(_attackDetails);
        }
    }

    // private void OnDrawGizmos() 
    // {
    //     Gizmos.DrawSphere(meleeAttackTranform.position, meleeAttackData.AttackRadius);
    // }
}
