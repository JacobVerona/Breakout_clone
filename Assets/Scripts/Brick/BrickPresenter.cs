using UnityEngine;

public class BrickPresenter : MonoBehaviour
{
    [SerializeField] private BricksDataRepository _repository;
    [SerializeField] private Brick _brick;
    [SerializeField] private SpriteRenderer _renderer;

    private BonusSpawner _bonusSpawner;

    public void OnDestroy ()
    {
        UnInit();
    }

    public void Init (BricksDataRepository repository, BonusSpawner bonusSpawner)
    {
        _repository = repository;
        _bonusSpawner = bonusSpawner;

        _brick.OnHealthChanges += ChangeBrickColor;
        _brick.OnBrickDestroy += _bonusSpawner.BrickDestroy;
    }

    public void UnInit ()
    {
        _brick.OnBrickDestroy -= _bonusSpawner.BrickDestroy;
        _brick.OnHealthChanges -= ChangeBrickColor;
    }

    public void ChangeBrickColor (int health)
    {
        if (_repository.TryGetData(health, out BrickData brickData))
        {
            _renderer.color = brickData.Color;
        }
    }
}
