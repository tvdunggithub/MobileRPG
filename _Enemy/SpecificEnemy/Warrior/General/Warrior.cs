using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Warrior : Enemy
{
   [SerializeField]
   private D_EnemyIdle _idleData;
   [SerializeField]
   private D_EnemyMove _walkData;
   [SerializeField]
   private D_EnemyMove _runData;
   [SerializeField]
   private D_EnemyMeleeAttack _meleeAttackData;
   [SerializeField]
   private D_EnemyProtectState _protectData;
   [SerializeField]
   private Transform _overlapAttackPointA;
   [SerializeField]
   private Transform _overlapAttackPointB;
   [SerializeField]
   private Transform _meleeAttackPos;
   [SerializeField]
   private Transform _playerCheckPos;

   public WarriorIdleState IdleState { get; private set; }
   public WarriorRunState RunState { get; private set; }
   public WarriorWalkState WalkState { get; private set; }
   public WarriorMeleeAttackState MeleeAttackState { get; private set; }
   public WarriorProtectState ProtectState { get; private set; }

   public bool _isProtectState;

    public override void Start() 
    {
        base.Start();
        IdleState = new WarriorIdleState(this, StateMachine, "idle", _idleData, this);
        WalkState = new WarriorWalkState(this, StateMachine, "walk", _walkData, this);
        RunState = new WarriorRunState(this, StateMachine, "run", _runData, this);
        DeadState = new WarriorDeadState(this, StateMachine, "dead");
        MeleeAttackState = new WarriorMeleeAttackState(this, StateMachine, "meleeAttack", _meleeAttackData, this);
        ProtectState = new WarriorProtectState(this, StateMachine, "protect", _protectData, this);

        StateMachine.Initialize(IdleState);
        IsFacingRight = true;
        _attackDetails.DamageAmount = _meleeAttackData.AttackDamage;
    }

    public virtual bool CheckPlayerInAttackRange()
    {
        return Physics2D.OverlapCircle(_playerCheckPos.transform.position, _meleeAttackData.AttackRadius, EnemyBaseData.whatIsPlayer);
    }

    public virtual void AttackPlayer()
    {
        Collider2D detectedObject = Physics2D.OverlapArea(_overlapAttackPointA.position, _overlapAttackPointB.position, EnemyBaseData.whatIsPlayer);
        if(detectedObject != null)
        {
            PlayerDamageable playerDamageable = detectedObject.GetComponent<PlayerDamageable>();
            playerDamageable.Damage(_attackDetails);
        }
    }

    public void ChangeIdleStateCo(float waitTime)
    {
        StartCoroutine(ChangeIdleState(waitTime));
    }

    private IEnumerator ChangeIdleState(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _isProtectState = false;
        StateMachine.CurrentState.CanChangeState = true;
        StateMachine.ChangeState(IdleState);
    }

    // private void OnDrawGizmos() 
    // {
    //     Gizmos.DrawCube(_meleeAttackPos.position, _meleeAttackData.BoxSize);
    //     Gizmos.DrawSphere(_playerCheckPos.transform.position, _meleeAttackData.AttackRadius);
    // }

}
