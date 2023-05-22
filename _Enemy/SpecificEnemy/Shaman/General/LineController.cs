using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineController : MonoBehaviour
{
    private LineRenderer _line;
    private Rigidbody2D _rb;
    private Shaman _shaman;
    public bool IsActive;

    [SerializeField]
    private Transform _posOne;
    [SerializeField]
    private Transform _posTwo;
    private Vector3[] _lineArray;


    private void Awake() 
    {
        _line = GetComponent<LineRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _shaman = transform.parent.GetComponentInParent<Shaman>();
        _rb.simulated = false;
        _line.material.SetColor("_Color", new Color(1f, 1f, 1f, 0.15f));
        _lineArray = new Vector3[2];
        _lineArray[0] = _posOne.position;
        _lineArray[1] = _posTwo.position;

    }

    private void OnEnable() 
    {
        _lineArray[0] = _posOne.position;
        _lineArray[1] = _posTwo.position;
        _line.SetPositions(_lineArray);
        IsActive = false;
        _line.material.SetColor("_Color", new Color(1f, 1f, 1f, 0.15f));
        _rb.simulated = false;
    }

    private void Start()
    {
        _line.SetPositions(_lineArray);
    }

    private void Update() 
    {
        if(IsActive)
        {
            _rb.simulated = true;
            _line.material.SetColor("_Color", new Color(1f, 1f, 1f, 1f));
        }
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.CompareTag("Player"))
        {
            PlayerDamageable playerDamageable = other.GetComponent<PlayerDamageable>();
            playerDamageable.Damage(_shaman.MagicOneAttackDetails);
        }
    }

    private void OnDrawGizmos() {
        Gizmos.DrawLine(_lineArray[0], _lineArray[1]);
    }
}
