using System;
using UnityEngine;

public class DeathScreenUI : MonoBehaviour
{
    public event Action OnMainMenuButtonPressed;

    public void RestartButton ()
    {
        OnMainMenuButtonPressed?.Invoke();
    }
}