using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Player : MonoBehaviour
{
    public PlayerStateMachine StateMachine { get; private set; }

    [SerializeField]
    private PlayerData _playerData;
    [SerializeField]
    private Transform _meleeAttackPoint;
    [SerializeField]
    private Transform _spellPoint;
    [SerializeField]
    private HpController _hpController;
    public HpController HpController { get { return _hpController; } }
    [HideInInspector]
    public Transform Transform;
    public GameObject SpellPrefab;
    [HideInInspector]
    public bool IsDied;
    
    public PlayerData PlayerData
    {
        get { return _playerData; }
    }
    public Transform MeleeAttackPoint
    {
        get { return _meleeAttackPoint; }
    }
    public Transform SpellPoint
    {
        get { return _spellPoint; }
    }
    public Animator Anim { get; private set; }
    public PlayerInput PlayerInput { get; private set; }
    public Rigidbody2D RB { get; private set; }
    public BoxCollider2D MovementCollider { get; private set; }
    public Vector2 CurrentVelocity { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerDashState DashState { get; private set; }
    public PlayerDeadState DeadState { get; private set; }
    public PlayerMeleeAttackState AttackState { get; private set; }
    public PlayerSpellState SpellState { get; private set; }
    public bool IsPlayerFacingRight { get; private set; }
    private float _joystickAngle;
    public bool CanDash { get; private set; }
    public bool CanAttack { get; private set; }
    public bool CanSpell { get; private set; }
    public bool IsDashing { get; private set; }
    public float DashCoolDown { get; private set; }
    public float SpellCoolDown { get; private set; }
    public float CurrentHeal { get; set; }
    public Vector2 SpellDirection { get; private set; }
    private Vector2 _minPos;
    public AttackDetails MeleeAttackDetails;
    public AttackDetails SpellAttackDetails;
    
    

    private void Awake() 
    {
        StateMachine = new PlayerStateMachine();

        Anim = GetComponent<Animator>();
        RB = GetComponent<Rigidbody2D>();
        MovementCollider = GetComponent<BoxCollider2D>();
        PlayerInput = GetComponent<PlayerInput>();
        IsPlayerFacingRight = true;
        CanDash = true;
        CanAttack = true;
        CanSpell = true;
        IsDashing = false;
        Transform = transform;
        DashCoolDown = PlayerData.DashCoolDown;
        SpellCoolDown = PlayerData.SpellCooldown;

    }

    private void Start()
    {
        IdleState = new PlayerIdleState(this, StateMachine, _playerData, StaticString.Idle);
        MoveState = new PlayerMoveState(this, StateMachine, _playerData, StaticString.Move);
        DashState = new PlayerDashState(this, StateMachine, _playerData, StaticString.Dash);
        DeadState = new PlayerDeadState(this, StateMachine, _playerData, StaticString.Dead);
        AttackState = new PlayerMeleeAttackState(this, StateMachine, _playerData, StaticString.Attack);
        SpellState = new PlayerSpellState(this, StateMachine, _playerData, StaticString.Spell);
        CurrentHeal = _playerData.HP;
        MeleeAttackDetails.DamageAmount = PlayerData.DamageAmount;
        SpellAttackDetails.DamageAmount = PlayerData.SpellDamage;
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        StateMachine.CurrentState.LogicUpdate();    
        UpdateCoolDown();
        Transform.position = new Vector2(
            Mathf.Clamp(Transform.position.x, -29, 123),
            Mathf.Clamp(Transform.position.y, -4, 4)
        );
    }

    private void FixedUpdate() 
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    private void UpdateCoolDown()
    {
        if(DashCoolDown < PlayerData.DashCoolDown)
            DashCoolDown += Time.deltaTime;
        if(SpellCoolDown < PlayerData.SpellCooldown)
            SpellCoolDown += Time.deltaTime;
        else
            CanSpell = true;
    }

    private void Flip()
    {
        Transform.Rotate(0, 180f, 0);
        IsPlayerFacingRight = !IsPlayerFacingRight;
    }

    public void CheckIfShouldFlip(Vector2 input)
    {
        _joystickAngle = Vector2.SignedAngle(Vector2.up, input);
        if(IsPlayerFacingRight && _joystickAngle > 0)
            Flip();    
        if(!IsPlayerFacingRight && _joystickAngle < 0)
            Flip();
    }

    public void SetVelocity(Vector2 input)
    {
        RB.velocity = input * _playerData.MoveSpeed;
    }

    public void CheckEnemyxPosInRange()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCircleAll(Transform.position, PlayerData.EnemyCheckRadius, PlayerData.WhatIsEnemy );
        float xPosCompareTemp;
        float minxPosCompare = PlayerData.EnemyCheckRadius;
        if(detectedObjects != null)
        {
            foreach(Collider2D collider in detectedObjects)
            {
                xPosCompareTemp = Math.Abs(collider.gameObject.transform.position.x - Transform.position.x);
                if(minxPosCompare > xPosCompareTemp)
                {
                    minxPosCompare = xPosCompareTemp;
                    _minPos = collider.gameObject.transform.position;
                }
            }
        }
        if(_minPos != Vector2.zero)
        {
            Vector2 temp = new Vector2(_minPos.x - Transform.position.x, _minPos.y - Transform.position.y);
            temp.Normalize();
            SpellDirection = temp;
        }else
        {
            SpellDirection = Transform.right;
        }
    }

    public void ResetSpellCoolDown()
    {
        SpellCoolDown = 0;
        CanSpell = false;
    }

    public void FlipPlayerOnSpell()
    {
        if(IsPlayerFacingRight && SpellDirection.x < 0)
            Flip();
        if(!IsPlayerFacingRight && SpellDirection.x > 0)
            Flip();
    }

    public void Dash()
    {
        StartCoroutine(DashIE());
    }

    private IEnumerator DashIE()
    {
        CanDash = false;
        gameObject.tag = StaticString.Immune;
        DashCoolDown = 0;
        IsDashing = true;
        yield return new WaitForSeconds(PlayerData.DashTime);
        IsDashing = false;
        gameObject.tag = StaticString.Player;
        yield return new WaitForSeconds(PlayerData.DashCoolDown);
        CanDash = true;
    }
    private IEnumerator SpellIE()
    {
        yield return new WaitForSeconds(PlayerData.SpellCooldown);
    }

    public void IsAnimationFinished()
    {
        StateMachine.CurrentState._isAnimationFinished = true;
    }

    public void AttackAnimationFinished()
    {
        CanAttack = true;
        StateMachine.ChangeState(IdleState);
    }

    public void SetAttack()
    {
        CanAttack = false;
    }
    public void TriggerSpell()
    {
        GameObject.Instantiate(SpellPrefab, SpellPoint.position, Quaternion.identity);
        StateMachine.CurrentState.CanChangeState = true;
        SpellAttackDetails.Position = Transform.position;
        StateMachine.ChangeState(IdleState);
    }

    public void TriggerAttack()
    {
        Collider2D[] detectedObjects = Physics2D.OverlapCapsuleAll(MeleeAttackPoint.position, PlayerData.AttackCapsuleSize, CapsuleDirection2D.Horizontal, 0, PlayerData.WhatIsEnemy);
        //[] => detectedObject != null ????
        if(detectedObjects != null)
        {
            foreach(Collider2D collider in detectedObjects)
            {
                IDamageable enemyIdamageable = collider.GetComponentInParent<IDamageable>();
                enemyIdamageable.Damage(MeleeAttackDetails);
            }
        }
    }

    // public void OnDrawGizmos() 
    // {
    //     Gizmos.DrawCube(MeleeAttackPoint.position, PlayerData.AttackCapsuleSize);
    // }

    

}

