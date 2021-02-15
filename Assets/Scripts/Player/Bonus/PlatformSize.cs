using UnityEngine;

public class PlatformSize : BonusBase
{
    private float multiplyValue = 2f;
    private float duration = 20f;

    private Platform _platform;

    public override float Duration => duration;

    public PlatformSize (Platform platform)
    {
        _platform = platform;
    }

    public override void Init ()
    {
        Vector3 scale = _platform.transform.localScale;
        _platform.transform.localScale = new Vector3(scale.x * multiplyValue, scale.y, scale.z);
    }

    public override void UnInit ()
    {
        Vector3 scale = _platform.transform.localScale;
        _platform.transform.localScale = new Vector3(scale.x / multiplyValue, scale.y, scale.z);
    }
}

public class AddBall : BonusBase
{
    private Player _player;

    public override float Duration => 0f;

    public AddBall (Player player)
    {
        _player = player;
    }

    public override void Init ()
    {
        _player.AddBall();
    }
}