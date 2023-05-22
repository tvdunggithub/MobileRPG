using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goblem : Enemy
{

    [SerializeField]
    private D_EnemyIdle idleData;
    [SerializeField]
    private D_EnemyPlayerDetected playerDetectedData;
    [SerializeField]
    private D_EnemyRangedData throwingData;
    [SerializeField]
    private Transform projectileTransform;

    public GoblemIdleState IdleState { get; private set; }
    public GoblemPlayerDetectedState PlayerDetectedState { get; private set; }
    public GoblemThrowingState ThrowingState { get; private set; }
    [HideInInspector]
    public Vector2 ShootDirection; 
    [HideInInspector]
    public LineRenderer LineRenderer;
    public Transform ProjectileTransform
    {
        get { return projectileTransform; }
        private set { projectileTransform = value; }
    }

    public override void Awake() 
    {
        base.Awake();
        LineRenderer = AliveGO.GetComponent<LineRenderer>();
    }
    
    public override void Start() 
    {
        base.Start();
        IdleState = new GoblemIdleState(this, StateMachine, "idle", idleData, this);
        PlayerDetectedState = new GoblemPlayerDetectedState(this, StateMachine, "playerDetected", playerDetectedData, this);
        ThrowingState = new GoblemThrowingState(this, StateMachine, "throwing", throwingData, this);
        DeadState = new GoblemDeadState(this, StateMachine, "dying", this);
        
        _attackDetails.DamageAmount = throwingData.AttackDamage;
        IsFacingRight = true;

        StateMachine.Initialize(IdleState);
    }


}
