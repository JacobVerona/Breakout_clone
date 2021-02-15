using System.Collections;
using UnityEngine.SceneManagement;

public class GameOver : GameState
{
    private DeathScreenUI _deathScreen;

    public GameOver (DeathScreenUI deathScreen)
    {
        _deathScreen = deathScreen;
        _deathScreen.gameObject.SetActive(false);
    }

    public override void Init ()
    {
        _deathScreen.gameObject.SetActive(true);
        _deathScreen.OnMainMenuButtonPressed += BackToMainMenu;
    }

    public override void UnInit ()
    {
        _deathScreen.OnMainMenuButtonPressed -= BackToMainMenu;
        _deathScreen.gameObject.SetActive(false);
    }

    private void BackToMainMenu ()
    {
        //var currentScene = SceneManager.GetActiveScene();
        // SceneManager.LoadScene(currentScene.name);
        GameStateHandler.SetState<MainMenu>();
    }
}
