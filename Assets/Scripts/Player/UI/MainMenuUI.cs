using System;
using UnityEngine;

public class MainMenuUI : MonoBehaviour
{
    public event Action OnStartButtonPressed;
    public event Action OnExitButtonPressed;

    public void StartButton ()
    {
        OnStartButtonPressed?.Invoke();
    }

    public void ExitButton ()
    {
        OnExitButtonPressed?.Invoke();
    }
}