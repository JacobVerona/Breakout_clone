using UnityEngine;

public abstract class GameState
{
    protected GameStateHandler GameStateHandler { get; private set; }

    public void SetStateHandler (GameStateHandler gameState)
    {
        GameStateHandler = gameState;
    }

    public virtual void Init () { }
    public virtual void Update () { }
    public virtual void UnInit () { }
}