using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkMagicPlayerDetectedState : EnemyPlayerDetectedState
{
    private DarkMagic darkMagic;
    private Vector3 temp = new Vector3(0, -0.5f, 0);
    public DarkMagicPlayerDetectedState(Enemy enemy, EnemyStateMachine stateMachine, string animBoolName, D_EnemyPlayerDetected enemyPlayerDetectedData, DarkMagic darkMagic) : base(enemy, stateMachine, animBoolName, enemyPlayerDetectedData)
    {
        this.darkMagic = darkMagic;
    }

    public override void Enter()
    {
        base.Enter();
        GameObject magicAim = GameObject.Instantiate(darkMagic.MagicAimGO, darkMagic.Player.transform.position + temp, Quaternion.identity, darkMagic.transform);
        darkMagic.magicAimAnimator = magicAim.GetComponent<Animator>();
        darkMagic.MagicAim = magicAim.GetComponent<MagicAim>();
        darkMagic.StartCoroutineChangeSpellState(enemyPlayerDetectedData.agrroTime);
    }

}
