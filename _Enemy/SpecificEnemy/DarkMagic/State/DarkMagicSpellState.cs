using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicSpellState : EnemyAttackState
{
    private D_EnemySpell _spellData;
    private DarkMagic _darkMagic;
    public DarkMagicSpellState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemySpell spellData, DarkMagic darkMagic) : base(enemy, stateMachine, animBoolName)
    {
        this._spellData = spellData;
        this._darkMagic = darkMagic;
    }

    public override void Enter()
    {
        base.Enter();
        _darkMagic._attackDetails.Position = _darkMagic.Transform.position;
    }

    public override void TriggerAttack()
    {
        base.TriggerAttack();
        _darkMagic.Explosion();
        _darkMagic.MagicAim._isExploding = true;
        _darkMagic.MagicAim.Rb.simulated = true;
    }

    public override void FinishAttack()
    {
        base.FinishAttack();
        StateMachine.ChangeState(_darkMagic.IdleState);
    }
}
