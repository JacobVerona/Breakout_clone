using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public event Action<Ball> OnBallDestroy;

    [SerializeField] private Rigidbody2D _rigidbody2D;
    [SerializeField] private Player _player;

    private Vector3 _oldVelocity;

    public Player Player 
    { 
        get => _player; 
        set => _player = value;
    }

    public void OnEnable ()
    {
        _rigidbody2D.velocity = Vector2.up;
    }

    public void FixedUpdate ()
    {
        _rigidbody2D.velocity = _rigidbody2D.velocity.normalized * 8f;
        _oldVelocity = _rigidbody2D.velocity;
    }

    public void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out IBallHittable hittable))
        {
            hittable.Hit(this, 1);
        }
        _rigidbody2D.velocity = Vector2.Reflect(_oldVelocity, collision.contacts[0].normal);
    }

    public void OnBecameInvisible ()
    {
        OnBallDestroy?.Invoke(this);
    }
}