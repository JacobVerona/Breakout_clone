using UnityEngine;

public class BricksInstaller : MonoBehaviour
{
    [SerializeField] private BonusSpawner _bonusSpawner;

    [SerializeField] private BricksData _bricksData;
    [SerializeField] private BricksDataRepository _repository;
    [SerializeField] private BrickPresenter _prefab;

    private IGetBricksStrategy _getBrickStrategy;
    private BrickPresenter[] _brickPresenters;

    public void Init ()
    {
        _getBrickStrategy = new QuadInstantiate(transform, _prefab);

        _brickPresenters = _getBrickStrategy.Execute();

        _repository = new BricksDataRepository();
        _repository.LoadDatas(_bricksData);

        for (int i = 0; i < _brickPresenters.Length; i++)
        {
            _brickPresenters[i].Init(_repository, _bonusSpawner);
        }
    }
}
