using UnityEngine;

public class GetInChildren : IGetBricksStrategy
{
    private GameObject parent;

    public GetInChildren (GameObject parent)
    {
        this.parent = parent;
    }

    public BrickPresenter[] Execute ()
    {
        return parent.GetComponentsInChildren<BrickPresenter>();
    }
}
