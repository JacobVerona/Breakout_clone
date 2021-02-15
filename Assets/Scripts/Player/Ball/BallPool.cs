using UnityEngine;
using System.Collections.Generic;

public class BallPool : MonoBehaviour
{
    [SerializeField] private Ball _prefab;
    [SerializeField] private int _poolSize;

    private Stack<Ball> _balls;

    private void Awake ()
    {
        _balls = new Stack<Ball>(_poolSize);

        for (int i = 0; i < _poolSize; i++)
        {
            var ball = Instantiate(_prefab, transform);
            ball.gameObject.SetActive(false);
            _balls.Push(ball);
        }
    }

    public bool TryPop (out Ball ball)
    {
        if (_balls.Count <= 0)
        {
            ball = null;
            return false;
        }

        ball = _balls.Pop();
        ball.gameObject.SetActive(true);
        return true;
    }

    public void Push (Ball ball)
    {
        _balls.Push(ball);
        ball.gameObject.SetActive(false);
    }
}