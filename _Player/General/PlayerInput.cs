using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    private JoystickTest _joystick;
    private Vector2 _moveInput;

    public Vector2 MoveInput 
    {
        get { return _moveInput; }
        private set { _moveInput = value; }
    }

    private void Start()
    {

    }

    private void Update() 
    {
        OnMove();
    }

    public void OnMove()
    {
        _moveInput = _joystick.Input.normalized;
    }
}
