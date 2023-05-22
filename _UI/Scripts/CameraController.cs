using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform _player;
    [HideInInspector]
    public Transform Transform;

    private void Awake() {
        Transform = transform;
    }

    private void Update() 
    {
        ClampPosition();
    }

    private void ClampPosition()
    {
        if(_player != null)
        {
            Transform.position = new Vector3(
            Mathf.Clamp(_player.position.x, -20, 115), 
            Mathf.Clamp(_player.position.y, -0.05f, 0),
            Transform.position.z
            );
        }
    }
}
