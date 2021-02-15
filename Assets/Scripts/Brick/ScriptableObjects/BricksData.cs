using System;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BricksData", menuName = "BreakoutClone/BricksData")]
public class BricksData : ScriptableObject
{
    [SerializeField] private BrickData[] _bricksData;

    public BrickData[] BrickDatas => _bricksData;
}

[Serializable]
public class BrickData
{
    [SerializeField] private int health;
    [SerializeField] private Color32 color;

    public int Health => health;
    public Color32 Color => color;
}
