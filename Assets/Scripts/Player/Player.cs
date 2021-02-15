using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Platform _platform;
    [SerializeField] private BallPool _ballPool;

    [SerializeField] private List<Ball> _balls;

    public BonusHandler BonusHandler { get; private set; }
    public PlayerStats Stats { get; private set; }

    public Platform Platform { get => _platform; private set { _platform = value; } }

    public void Init ()
    {
        Stats = new PlayerStats();
        BonusHandler = new BonusHandler(this);
        _balls = new List<Ball>();

        AddBall();
    }

    public void InitStartStatsValues ()
    {
        Stats.Lifes = 3;
    }

    public void AddBall ()
    {
        if (_ballPool.TryPop(out Ball ball))
        {
            _balls.Add(ball);
            ball.transform.position = Vector2.zero;

            ball.Player = this;
            ball.OnBallDestroy += BallDestroyHandle;
        }
    }

    private void RemoveBall (Ball ball)
    {
        ball.OnBallDestroy -= BallDestroyHandle;
        _balls.Remove(ball);
        _ballPool.Push(ball);
    }

    private void BallDestroyHandle (Ball ball)
    {
        RemoveBall(ball);
        if (_balls.Count <= 0)
        {
            Stats.Lifes--;
        }

        if (Stats.Lifes > 0)
        {
            AddBall();
        }
    }

    public void UnInit ()
    {
        for (int i = 0; i < _balls.Count; i++)
        {
            var ball = _balls[i];
            ball.OnBallDestroy -= BallDestroyHandle;
            _ballPool.Push(ball);
        }

        _balls.Clear();
    }
}
