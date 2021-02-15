using UnityEngine;

public class QuadInstantiate : IGetBricksStrategy
{
    private Transform parent;
    private BrickPresenter prefab;

    private int width = 35;
    private int height = 3;

    public QuadInstantiate (Transform parent, BrickPresenter prefab)
    {
        this.parent = parent;
        this.prefab = prefab;
    }

    public BrickPresenter[] Execute ()
    {
        Vector3 offset = parent.transform.position;
        BrickPresenter[] bricks = new BrickPresenter[width*height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                bricks[x * height + y] = Object.Instantiate(prefab, offset + (new Vector3(x, y) / 2f), Quaternion.identity, parent);
                bricks[x * height + y].GetComponent<Brick>().Health = y+1;
            }
        }

        return bricks;
    }
}