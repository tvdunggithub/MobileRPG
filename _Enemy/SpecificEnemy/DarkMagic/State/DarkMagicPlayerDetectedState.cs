using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicPlayerDetectedState : EnemyPlayerDetectedState
{
    private DarkMagic _darkMagic;
    private Vector3 _temp = new Vector3(0, -0.5f, 0);
    public DarkMagicPlayerDetectedState(Enemy enemy, EnemyStateMachine stateMachine, int animBoolName, D_EnemyPlayerDetected enemyPlayerDetectedData, DarkMagic darkMagic) : base(enemy, stateMachine, animBoolName, enemyPlayerDetectedData)
    {
        this._darkMagic = darkMagic;
    }

    public override void Enter()
    {
        base.Enter();
        GameObject magicAim = GameObject.Instantiate(_darkMagic.MagicAimGO, _darkMagic.Player.Transform.position + _temp, Quaternion.identity, _darkMagic.Transform);
        _darkMagic.MagicAimAnimator = magicAim.GetComponent<Animator>();
        _darkMagic.MagicAim = magicAim.GetComponent<MagicAim>();
        _darkMagic.StartCoroutineChangeSpellState(_enemyPlayerDetectedData.AgrroTime);
    }

}
