using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicThree : MonoBehaviour
{
    private Rigidbody2D _rb;
    private Animator _aim;
    private Shaman _shaman;
    private Player _player;
    private Vector2 _chaseDirection;
    private bool _isExplosion;
    private bool _isPlayerStopped;
    public Transform Transform;
    [SerializeField]
    private float _chaseSpeed;
    private WaitForSeconds _waitForSecondsStop;

    private void Awake() 
    {
        _rb = GetComponent<Rigidbody2D>();
        _aim = GetComponent<Animator>();
        _player = GameObject.Find(StaticString.Player).GetComponent<Player>();
        _shaman = GetComponentInParent<Shaman>();
        _aim.SetBool(StaticString.Chasing, true);
        _waitForSecondsStop = new WaitForSeconds(0.2f);
        Transform = transform;
    }

    private void Update() 
    {
        CalculateDrection(); 
        Damage();
    }

    private void FixedUpdate() 
    {
        StopIfPlayerStop();
        SetVelocity();
    }

    private void CalculateDrection()
    {
        if(_isExplosion)
            return;
        _chaseDirection.x = _player.Transform.position.x - Transform.position.x;
        _chaseDirection.y = _player.Transform.position.y - Transform.position.y;
        _chaseDirection.Normalize();
    }

    private void ChangeExplosionState()
    {
        _aim.SetBool(StaticString.Chasing, false);
        _aim.SetBool(StaticString.Explosion, true);
        _rb.velocity = Vector2.zero;
        _isExplosion = true;
    }

    private void SetVelocity()
    {
        if(_isExplosion || _isPlayerStopped)
            return;
        _rb.velocity = _chaseDirection * _chaseSpeed;
    }

    private void AnimationFinished()
    {
        Destroy(gameObject);
    }

    private void StopIfPlayerStop()
    {
        if(_shaman.Player == null)
            return;
        if(IsPlayerInMinRange())
        {
            _isPlayerStopped = true;
            StartCoroutine(Stop());
        }          
    }

    private bool IsPlayerInMinRange()
    {
        if(_shaman.Player == null)
            return false;
        return Mathf.Abs(Transform.position.x - _player.Transform.position.x) <= 0.1 
                && Mathf.Abs(Transform.position.y - _player.Transform.position.y) <= 0.1;
    }

    private bool IsPlayerInMaxRange()
    {
        if(_shaman.Player == null)
            return false;
        return Mathf.Abs(Transform.position.x - _player.Transform.position.x) <= 0.8 
                && Mathf.Abs(Transform.position.y - _player.Transform.position.y) <= 0.8;
    }

    private void Damage()
    {
        if(IsPlayerInMaxRange() && _isExplosion)
            _player.GetComponent<PlayerDamageable>().Damage(_shaman.MagicThreeAttackDetails);
    }

    private IEnumerator Stop()
    {
        _rb.velocity = Vector2.zero;       
        yield return _waitForSecondsStop;
        _isPlayerStopped = false;
    }

}
