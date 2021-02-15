using UnityEngine;

public class GameStateHandler : MonoBehaviour
{
    [SerializeField] private MainMenuUI _mainMenu;
    [SerializeField] private GameObject _level;

    [SerializeField] private Player _player;
    [SerializeField] private BricksInstaller _bricksInstaller;
    [SerializeField] private PlayerStatsPresenter _playerStatsPresenter;

    [SerializeField] private DeathScreenUI _deathScreen;

    private GameState _currentState;
    private GameStatesRepository _statesRepository;

    public void Awake ()
    {
        Init();
    }

    public void Init ()
    {
        _statesRepository = new GameStatesRepository();

        var mainMenu = new MainMenu(_mainMenu);
        var levelInit = new LevelInitialization(_level, _player, _bricksInstaller, _playerStatsPresenter);
        var playing = new Playing(_level, _player, _playerStatsPresenter);
        var gameOver = new GameOver(_deathScreen);

        _statesRepository.Register(mainMenu);
        _statesRepository.Register(levelInit);
        _statesRepository.Register(playing);
        _statesRepository.Register(gameOver);

        _currentState = _statesRepository.Get<MainMenu>();
        _currentState.SetStateHandler(this);
        _currentState.Init();

        //DontDestroyOnLoad(this);
    }

    public void SetState<T> () where T : GameState
    {
        _currentState.UnInit();

        var nextState = _statesRepository.Get<T>();
        _currentState = nextState;

        _currentState.SetStateHandler(this);
        _currentState.Init();
    }

    public void Update ()
    {
        _currentState.Update();
    }
}
