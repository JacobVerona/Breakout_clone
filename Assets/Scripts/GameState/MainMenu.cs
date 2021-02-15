using UnityEngine;

public class MainMenu : GameState
{
    private MainMenuUI _menuObject;

    public MainMenu (MainMenuUI menuObject)
    {
        _menuObject = menuObject;
    }

    public override void Init ()
    {
        _menuObject.gameObject.SetActive(true);
        _menuObject.OnStartButtonPressed += StartGame;
        _menuObject.OnExitButtonPressed += ExitGame;
    }

    public override void UnInit ()
    {
        _menuObject.OnStartButtonPressed -= StartGame;
        _menuObject.OnExitButtonPressed -= ExitGame;
        _menuObject.gameObject.SetActive(false);
    }

    private void StartGame ()
    {
        GameStateHandler.SetState<LevelInitialization>();
    }

    private void ExitGame ()
    {
        Application.Quit();
    }
}
