using UnityEngine;

public class BonusSpawner : MonoBehaviour
{
    [SerializeField] private BonusBehaviour[] bonusPrefabs;

    public void BrickDestroy (Brick brick)
    {
        if (Random.Range(0, 10) > 5 )
        {
            SpawnBonus(brick.transform.position);
        }
    }

    private void SpawnBonus (Vector3 position)
    {
        int bonusIndex = Random.Range(0, bonusPrefabs.Length);

        Instantiate(bonusPrefabs[bonusIndex], position, Quaternion.identity, transform);
    }
}
