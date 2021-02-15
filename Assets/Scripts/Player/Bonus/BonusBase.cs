public abstract class BonusBase
{
    public abstract float Duration { get; }

    public abstract void Init ();

    public virtual void UnInit () { }
}
