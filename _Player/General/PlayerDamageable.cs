using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamageable : MonoBehaviour, IDamageable
{
    private Player _player;
    private SpriteRenderer _spriteRenderer;
    private Color _originColor;
    private Color _twinklingColor;
    private bool _isTwinklingTimeEnd;
    private WaitForSeconds _waitForSecondsTwinklingTime;
    private WaitForSeconds _waitForSecondsChangeColorTime;
    private void Awake() 
    {
        _player = GetComponent<Player>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _originColor = new Color(1f, 1f, 1f, 1f);
        _twinklingColor = new Color(1f, 1f, 1f, 0.1f);
        _isTwinklingTimeEnd = true;
        _waitForSecondsTwinklingTime = new WaitForSeconds(_player.PlayerData.TwinklingTime);
        _waitForSecondsChangeColorTime = new WaitForSeconds(_player.PlayerData.ChangeColorTime);
    }

    public void Damage(AttackDetails attackDetails)
    {
        if(gameObject.tag == StaticString.Immune)
            return;
        _player.CurrentHeal -= attackDetails.DamageAmount;
        if(_player.CurrentHeal <= 0)
        {
            _player.CurrentHeal = 0;
            _player.StateMachine.ChangeDeadState(_player.DeadState);
            _player.IsDied = true;
        }    
        DamageEffect();      
        _player.HpController.ReduceHp(_player.CurrentHeal/_player.PlayerData.HP);
    }

    public void DamageEffect()
    {
        _isTwinklingTimeEnd = false;
        StartCoroutine(ColorEffect());
        StartCoroutine(CountTwinklingTime());
    }
    
    private IEnumerator CountTwinklingTime()
    {
        gameObject.tag = StaticString.Immune;
        yield return _waitForSecondsTwinklingTime;
        _isTwinklingTimeEnd = true;
        gameObject.tag = StaticString.Player;
    }

    private IEnumerator ColorEffect()
    {
        while(!_isTwinklingTimeEnd)
        {
            _spriteRenderer.color = _twinklingColor;
            yield return _waitForSecondsChangeColorTime;
            _spriteRenderer.color = _originColor;
            yield return _waitForSecondsChangeColorTime;
        }
        
    }
}
