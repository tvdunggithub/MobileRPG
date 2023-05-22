using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public EnemyStateMachine StateMachine { get; private set; }
    public Animator Anim { get; private set; }
    public GameObject AliveGO { get; private set; }
    private Rigidbody2D _rb;
    public GameObject Player { get; private set; }
    public SpriteRenderer SpriteRenderer { get; private set; }
    public AnimationToStateMachine Atsm { get; protected set; }
    public AttackDetails _attackDetails;
    public float CurrentHeal { get; set; }
    
    [HideInInspector]
    public bool IsFacingRight;
    [HideInInspector]
    public bool IsIdling;
    [HideInInspector]
    public bool IsAimTimeFinish;
    [HideInInspector]
    public bool CanAttack;

    public D_EnemyBase EnemyBaseData;
    [SerializeField]
    private GameObject DamageText;
    public EnemyDeadState DeadState { get; protected set; }

    public virtual void Awake()
    {
        AliveGO = transform.Find("Alive").gameObject;
        _rb = AliveGO.GetComponent<Rigidbody2D>();
        Anim = AliveGO.GetComponent<Animator>();
        Atsm = AliveGO.GetComponent<AnimationToStateMachine>();
        SpriteRenderer = AliveGO.GetComponent<SpriteRenderer>();
        StateMachine = new EnemyStateMachine();
        Player = GameObject.Find("Player");
        CanAttack = true;
    }

    public virtual void Start()
    {
        CurrentHeal = EnemyBaseData.MaxHp;
    }

    public virtual void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }

    public virtual void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicUpdate();
    }

    public virtual void SetVelocity(Vector2 velocity)
    {
        _rb.velocity = velocity;
    }

    public virtual bool CheckPlayerInMinAggroRange()
    {
        return Physics2D.OverlapCircle(AliveGO.transform.position, EnemyBaseData.playerDetectedRadius, EnemyBaseData.whatIsPlayer);
    }

    private IEnumerator WaitAndFlipWhenIdling(float waitTime)
    {
        while(IsIdling)
        {
            Flip();
            IsFacingRight = !IsFacingRight;
            yield return new WaitForSeconds(waitTime);
        }
    }

    public void StartCoroutineToFlip(float waitTime)
    {
        StartCoroutine(WaitAndFlipWhenIdling(waitTime));
    }

    private IEnumerator Aim(float aimTime)
    {
        yield return new WaitForSeconds(aimTime);
        IsAimTimeFinish = true;
    }
    public void StartCoroutineChangeStateAndFlip(float waitTime, EnemyState enemystate)
    {
        StartCoroutine(ChangeStateAndFlip(waitTime, enemystate));
    }

    private IEnumerator ChangeStateAndFlip(float waitTime, EnemyState enemystate)
    {
        yield return new WaitForSeconds(waitTime);
        Flip();
        IsFacingRight = !IsFacingRight;
        StateMachine.ChangeState(enemystate);
    }

    public void StartCoroutineChangeState(float waitTime, EnemyState enemystate)
    {
        StartCoroutine(WaitAndChangeState(waitTime, enemystate));
    }

    private IEnumerator WaitAndChangeState(float waitTime, EnemyState enemystate)
    {
        yield return new WaitForSeconds(waitTime);
        StateMachine.ChangeState(enemystate);
    }

    private IEnumerator WaitAndFlip(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        Flip();
        IsFacingRight = !IsFacingRight;
    }

    public void StartCoroutineFlip(float waitTime)
    {
        StartCoroutine(WaitAndFlip(waitTime));
    }

    public void StartAim(float aimTime)
    {
        StartCoroutine(Aim(aimTime));
    }

    public void Flip()
    {
        AliveGO.transform.Rotate(0,180,0);
    }

    public virtual void ChangeDeadState()
    {
        if(CurrentHeal <= 0)
            StateMachine.ChangeState(DeadState);
    }

    public virtual void Dead()
    {
        GameObject.Destroy(gameObject);
    }

    public virtual void FloatingDamageText(Vector3 enemyPosition, string damageAmount)
    {
        var FloatingGO = Instantiate(DamageText, enemyPosition, Quaternion.identity);
        FloatingGO.GetComponent<FloatingText>().textMesh.text = damageAmount.ToString();
        if(damageAmount == "Block")
            FloatingGO.GetComponent<FloatingText>().textMesh.color = Color.white;
    }
}
