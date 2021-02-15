using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private Player _parentPlayer;
    [SerializeField] private Vector2 _clampValues = new Vector2(-8, 8);
    private Camera _camera;

    public Player Player => _parentPlayer;

    public void Awake ()
    {
        _camera = Camera.main;
    }

    public void FixedUpdate ()
    {
        var pos = Input.mousePosition;
        var horizontalVelocity = _camera.ScreenToWorldPoint(pos).x;

        transform.position = new Vector2(Mathf.Clamp(horizontalVelocity, _clampValues.x, _clampValues.y), transform.position.y);
    }
}