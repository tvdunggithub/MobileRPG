using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagic : Enemy
{
    [SerializeField]
    private D_EnemyIdle idleData;
    [SerializeField]
    private D_EnemyPlayerDetected playerDetectedData;
    [SerializeField]
    private D_EnemySpell spellData;
    [SerializeField]
    private GameObject magicAimGO;
    [HideInInspector]
    public Animator magicAimAnimator;
    [HideInInspector]
    public MagicAim MagicAim;
    [HideInInspector]
    public bool IsExploding;
    public GameObject MagicAimGO
    {
        get { return magicAimGO; }
    }

    public DarkMagicIdleState IdleState { get; private set; }
    public DarkMagicPlayerDetectedState PlayerDetectedState { get; private set; }
    public DarkMagicSpellState SpellState { get; private set; }

    public override void Start()
    {
        base.Start();
        IdleState  = new DarkMagicIdleState(this, StateMachine, "idle", idleData,this);
        DeadState = new DarkMagicDeadState(this, StateMachine, "dead");
        PlayerDetectedState = new DarkMagicPlayerDetectedState(this, StateMachine, "playerDetected", playerDetectedData, this);
        SpellState = new DarkMagicSpellState(this, StateMachine, "spell" , spellData, this);
        _attackDetails.DamageAmount = spellData.spellDamage;

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
        magicAimAnimator.SetBool("aim", false);
        magicAimAnimator.SetBool("explosion", true);
    }

}
