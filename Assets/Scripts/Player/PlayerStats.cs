using System;

public class PlayerStats : IPlayerStatsEvents
{
    public event Action<int> OnScoreChanged;
    public event Action<int> OnLifesChanged;

    private int _lifes;
    private int _score;

    public int Lifes 
    { 
        get => _lifes; 
        set 
        { 
            _lifes = value; 
            OnLifesChanged?.Invoke(Lifes); 
        }
    }

    public int Score 
    { 
        get => _score; 
        set 
        { 
            _score = value; 
            OnScoreChanged?.Invoke(Score);
        }
    }

    public PlayerStats ()
    {
        _lifes = 0;
        _score = 0;
    }
}

public interface IPlayerStatsEvents
{
    public event Action<int> OnScoreChanged;
    public event Action<int> OnLifesChanged;
}