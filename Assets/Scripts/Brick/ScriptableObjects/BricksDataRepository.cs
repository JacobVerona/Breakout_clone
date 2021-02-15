using System.Collections.Generic;

public class BricksDataRepository
{
    private Dictionary<int, BrickData> _bricksDataDict;

    public BricksDataRepository ()
    {
        this._bricksDataDict = new Dictionary<int, BrickData>();
    }

    public void LoadDatas (BricksData bricksData)
    {
        var bricks = bricksData.BrickDatas;

        for (int i = 0; i < bricks.Length; i++)
        {
            var brick = bricks[i];
            _bricksDataDict.Add(brick.Health, brick);
        }
    }

    public bool TryGetData (int health, out BrickData data)
    {
        return _bricksDataDict.TryGetValue(health, out data);
    }
}