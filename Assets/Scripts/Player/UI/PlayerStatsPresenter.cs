using UnityEngine;
using TMPro;

public class PlayerStatsPresenter : MonoBehaviour
{
    private const string ScoreTextConst = "Current score: ";
    private const string LifeTextConst = "Lifes: ";

    [SerializeField] private TMP_Text _scoreText;
    [SerializeField] private TMP_Text _lifesText;

    private IPlayerStatsEvents _playerStatsEvents;

    public void OnDestroy ()
    {
        UnInit();
    }

    public void Init (IPlayerStatsEvents playerStats)
    {
        _playerStatsEvents = playerStats;

        _playerStatsEvents.OnScoreChanged += ScoreTextUpdate;
        _playerStatsEvents.OnLifesChanged += LifeTextUpdate;
    }

    public void UnInit ()
    {
        _playerStatsEvents.OnScoreChanged -= ScoreTextUpdate;
        _playerStatsEvents.OnLifesChanged -= LifeTextUpdate;
    }

    private void ScoreTextUpdate (int score)
    {
        _scoreText.text = ScoreTextConst + score;
    }

    private void LifeTextUpdate (int lifes)
    {
        _lifesText.text = LifeTextConst + lifes;
    }
}