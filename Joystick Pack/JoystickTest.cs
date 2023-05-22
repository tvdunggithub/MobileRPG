using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoystickTest : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{

    public float HandleRange
    {
        get { return _handleRange; }
        set { _handleRange = Mathf.Abs(value); }
    }

    public float DeadZone
    {
        get { return _deadZone; }
        set { _deadZone = Mathf.Abs(value); }
    }

    [SerializeField] private float _handleRange = 1;
    [SerializeField] private float _deadZone = 0;
    [SerializeField] protected RectTransform _background = null;
    [SerializeField] private RectTransform _handle = null;
    private RectTransform _baseRect = null;
    private Canvas _canvas;
    private Camera _cam;
    private Vector2 _rawInput = Vector2.zero;
    public Vector2 Input 
    {
        get { return _rawInput; }
        private set { _rawInput = value; }
    }

    private void Start()
    {
        HandleRange = _handleRange;
        DeadZone = _deadZone;
        _baseRect = GetComponent<RectTransform>();
        _canvas = GetComponentInParent<Canvas>();
        if (_canvas == null)
            Debug.LogError("The Joystick is not placed inside a canvas");

        Vector2 center = new Vector2(0.5f, 0.5f);

        _background.pivot = center;
        _handle.anchorMin = center;
        _handle.anchorMax = center;
        _handle.pivot = center;
        _handle.anchoredPosition = Vector2.zero;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        _cam = null;
        if (_canvas.renderMode == RenderMode.ScreenSpaceCamera)
            _cam = _canvas.worldCamera;

        Vector2 position = RectTransformUtility.WorldToScreenPoint(_cam, _background.position);
        Vector2 radius = _background.sizeDelta / 2;
        _rawInput = (eventData.position - position) / (radius * _canvas.scaleFactor);
        HandleInput(_rawInput.magnitude, _rawInput.normalized, radius, _cam);
        _handle.anchoredPosition = _rawInput * radius * _handleRange;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _rawInput = Vector2.zero;
        _handle.anchoredPosition = Vector2.zero;
    }

    public void HandleInput(float magnitude, Vector2 normalised, Vector2 radius, Camera cam)
    {
        if (magnitude > _deadZone)
        {
            if (magnitude > 1)
            {
                _rawInput = normalised;
            }
        }
        else
            _rawInput = Vector2.zero;
    }
}
