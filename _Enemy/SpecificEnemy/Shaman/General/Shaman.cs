using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaman : Enemy
{
    [SerializeField]
    private D_EnemyIdle _idleData;
    [SerializeField]
    private D_EnemyMove _walkData;
    [SerializeField]
    private D_ShamanMagicOne _magicOneData;
    [SerializeField]
    private D_ShamanMagicTwo _magicTwoData;
    [SerializeField]
    private D_ShamanMagicThree _magicThreeData;

    public Transform OppositePos;
    public GameObject SummonEnemy;
    public GameObject MagicThreePrefab;
    public GameObject[] LazeArray;
    public AttackDetails MagicOneAttackDetails;
    public AttackDetails MagicThreeAttackDetails;
    public HpController HpController;
    private SpriteRenderer _spriteRenderer;
    private float _colorA = 1f;

    public ShamanIdleState IdleState { get; private set; }
    public ShamanWalkState WalkState { get; private set; }
    public ShamanMagicOneState MagicOneState { get; private set; }
    public ShamanMagicTwoState MagicTwoState { get; private set; }
    public ShamanMagicThreeState MagicThreeState { get; private set; }
    public LineRenderer LineRenderer { get; private set; }

    public override void Awake() 
    {
        base.Awake();
        LineRenderer = GetComponent<LineRenderer>();
    } 

    public override void Start() 
    {
        base.Start();
        IdleState = new ShamanIdleState(this, StateMachine, StaticString.Idle, _idleData, this);
        WalkState = new ShamanWalkState(this, StateMachine, StaticString.Walk, _walkData, this);
        DeadState = new ShamanDeadState(this, StateMachine, StaticString.Dead);
        MagicOneState = new ShamanMagicOneState(this, StateMachine, StaticString.MagicOne, _magicOneData, this);
        MagicTwoState = new ShamanMagicTwoState(this, StateMachine, StaticString.MagicTwo, _magicTwoData, this);
        MagicThreeState = new ShamanMagicThreeState(this, StateMachine, StaticString.MagicThree, _magicThreeData, this);

        StateMachine.Initialize(IdleState);
        _spriteRenderer = AliveGO.GetComponent<SpriteRenderer>();
        MagicOneAttackDetails.DamageAmount = _magicOneData.DamageAmount;
        MagicThreeAttackDetails.DamageAmount = _magicThreeData.DamageAmount;
        Flip();
    }

    public void ChangeColorBeforeFlashCO()
    {
        StartCoroutine(ChangeColorBeforeFlash());
    }

    public void ResetColor()
    {
        StartCoroutine(ChangeColorAfterFlash());
    }

    private IEnumerator ChangeColorBeforeFlash()
    {
        while(_colorA >= 0)
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, _colorA);
            yield return new WaitForSeconds(0.2f);
            _colorA -= 0.09f;
        }
        
        Flash();
    }

    private IEnumerator ChangeColorAfterFlash()
    {
        while(_colorA <= 1)
        {
            _spriteRenderer.color = new Color(1f, 1f, 1f, _colorA);
            yield return new WaitForSeconds(0.2f);
            _colorA += 0.09f;
        }
        if(_colorA > 1)
            _colorA = 1;
    }

    public void Flash()
    {
        AliveGoTransform.position = OppositePos.position;
        Flip();
        IsFacingRight = !IsFacingRight;
        StateMachine.ChangeState(IdleState);
    }
  
}
