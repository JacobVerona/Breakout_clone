using UnityEngine;

public class Playing : GameState
{
    private Player _player;
    private PlayerStatsPresenter _playerStatsPresenter;

    private GameObject _level;

    public Playing (GameObject level, Player player, PlayerStatsPresenter playerStatsPresenter)
    {
        _level = level;
        _player = player;
        _playerStatsPresenter = playerStatsPresenter;
    }

    public override void Init ()
    {
        _player.Stats.OnLifesChanged += LifeChanged;
    }

    private void LifeChanged (int lifes)
    {
        if (lifes <= 0)
        {
            GameStateHandler.SetState<GameOver>();
        }
    }

    public override void UnInit ()
    {
        _player.Stats.OnLifesChanged -= LifeChanged;

        _player.UnInit();
        _playerStatsPresenter.UnInit();
        _level.SetActive(false);
    }

}
