using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagic : Enemy
{
    [SerializeField]
    private D_EnemyIdle _idleData;
    [SerializeField]
    private D_EnemyPlayerDetected _playerDetectedData;
    [SerializeField]
    private D_EnemySpell _spellData;
    [SerializeField]
    private GameObject _magicAimGO;
    [HideInInspector]
    public Animator MagicAimAnimator;
    [HideInInspector]
    public MagicAim MagicAim;
    [HideInInspector]
    public bool IsExploding;
    public GameObject MagicAimGO
    {
        get { return _magicAimGO; }
    }

    public DarkMagicIdleState IdleState { get; private set; }
    public DarkMagicPlayerDetectedState PlayerDetectedState { get; private set; }
    public DarkMagicSpellState SpellState { get; private set; }

    public override void Start()
    {
        base.Start();
        IdleState  = new DarkMagicIdleState(this, StateMachine, StaticString.Idle, _idleData,this);
        DeadState = new DarkMagicDeadState(this, StateMachine, StaticString.Dead);
        PlayerDetectedState = new DarkMagicPlayerDetectedState(this, StateMachine, StaticString.PlayerDetected, _playerDetectedData, this);
        SpellState = new DarkMagicSpellState(this, StateMachine, StaticString.Spell , _spellData, this);
        _attackDetails.DamageAmount = _spellData.SpellDamage;

        StateMachine.Initialize(IdleState);
    }

    private IEnumerator ChangeSpellState(float waitTime)
    {
            yield return new WaitForSeconds(waitTime);
            StateMachine.ChangeState(SpellState);
    }

    public void StartCoroutineChangeSpellState(float waitTime)
    {
        StartCoroutine(ChangeSpellState(waitTime));
    }

    public void Explosion()
    {
        MagicAimAnimator.SetBool("aim", false);
        MagicAimAnimator.SetBool("explosion", true);
    }

}
