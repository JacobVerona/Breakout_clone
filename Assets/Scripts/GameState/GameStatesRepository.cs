using System;
using System.Collections.Generic;
using UnityEngine;

public class GameStatesRepository
{
    private Dictionary<Type, GameState> states;

    public GameStatesRepository ()
    {
        states = new Dictionary<Type, GameState>();
    }

    public void Register (GameState state)
    {
        states.Add(state.GetType(), state);
    }

    public GameState Get<T> () where T : GameState
    {
        if (!states.ContainsKey(typeof(T)))
        {
            throw new KeyNotFoundException($"{typeof(T)} is not registered in GameStatesRepository");
        }
        return states[typeof(T)];
    }
}
