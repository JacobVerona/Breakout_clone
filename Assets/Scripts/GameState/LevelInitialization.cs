using UnityEngine;
public class LevelInitialization : GameState
{
    private GameObject _level;

    private Player _player;
    private BricksInstaller _bricksInstaller;
    private PlayerStatsPresenter _playerStatsPresenter;

    public LevelInitialization (GameObject level, Player player, BricksInstaller bricksInstaller, PlayerStatsPresenter playerStatsPresenter)
    {
        _level = level;
        _player = player;
        _bricksInstaller = bricksInstaller;
        _playerStatsPresenter = playerStatsPresenter;

    }

    public override void Init ()
    {
        _level.SetActive(true);

        _player.Init();

        _playerStatsPresenter.Init(_player.Stats);

        _player.InitStartStatsValues();
        _bricksInstaller.Init();

        GameStateHandler.SetState<Playing>();
    }
}