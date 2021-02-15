using System;
using UnityEngine;

public class Brick : MonoBehaviour, IBallHittable
{
    public event Action<int> OnHealthChanges;
    public event Action<Brick> OnBrickDestroy; 

    [SerializeField] private int _health;

    public int Health 
    { 
        get => _health; 
        set 
        {
            _health = value;
            OnHealthChanges?.Invoke(_health);
        }
    }

    public void Start ()
    {
        OnHealthChanges?.Invoke(_health);
    }

    public void Hit (Ball damagedBy, int damage)
    {
        var player = damagedBy.Player;

        Health -= damage;

        if (Health <= 0)
        {
            player.Stats.Score++;
            OnBrickDestroy?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
