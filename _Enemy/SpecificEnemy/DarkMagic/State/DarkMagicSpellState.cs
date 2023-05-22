using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicSpellState : EnemyAttackState
{
    private D_EnemySpell spellData;
    private DarkMagic darkMagic;
    public DarkMagicSpellState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemySpell spellData, DarkMagic darkMagic) : base(enemy, stateMachine, animBoolName)
    {
        this.spellData = spellData;
        this.darkMagic = darkMagic;
    }

    public override void Enter()
    {
        base.Enter();
        darkMagic._attackDetails.Position = darkMagic.transform.position;
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        darkMagic.Explosion();
        darkMagic.MagicAim._isExploding = true;
        darkMagic.MagicAim.Rb.simulated = true;
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        StateMachine.ChangeState(darkMagic.IdleState);
    }
}
