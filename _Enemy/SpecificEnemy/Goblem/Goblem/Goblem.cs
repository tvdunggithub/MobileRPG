using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblem : Enemy
{

    [SerializeField]
    private D_EnemyIdle _idleData;
    [SerializeField]
    private D_EnemyPlayerDetected _playerDetectedData;
    [SerializeField]
    private D_EnemyRangedData _throwingData;
    [SerializeField]
    private Transform _projectileTransform;

    public GoblemIdleState IdleState { get; private set; }
    public GoblemPlayerDetectedState PlayerDetectedState { get; private set; }
    public GoblemThrowingState ThrowingState { get; private set; }
    [HideInInspector]
    public Vector2 ShootDirection; 
    [HideInInspector]
    public LineRenderer LineRenderer;
    public Transform ProjectileTransform
    {
        get { return _projectileTransform; }
        private set { _projectileTransform = value; }
    }

    public override void Awake() 
    {
        base.Awake();
        LineRenderer = AliveGO.GetComponent<LineRenderer>();
    }
    
    public override void Start() 
    {
        base.Start();
        IdleState = new GoblemIdleState(this, StateMachine, StaticString.Idle, _idleData, this);
        PlayerDetectedState = new GoblemPlayerDetectedState(this, StateMachine, StaticString.PlayerDetected, _playerDetectedData, this);
        ThrowingState = new GoblemThrowingState(this, StateMachine, StaticString.Throwing, _throwingData, this);
        DeadState = new GoblemDeadState(this, StateMachine, StaticString.Dead, this);
        
        _attackDetails.DamageAmount = _throwingData.AttackDamage;
        IsFacingRight = true;

        StateMachine.Initialize(IdleState);
    }


}
