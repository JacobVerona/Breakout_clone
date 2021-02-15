using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputBehaviour : MonoBehaviour
{
    public event Action<Vector2> OnMouseWorldPosition;

    private Camera _camera;

    public void Awake ()
    {
        _camera = Camera.main;
    }

    public void Update ()
    {
        var pos = Input.mousePosition;
        OnMouseWorldPosition?.Invoke(_camera.ScreenToWorldPoint(pos));
    }

}
