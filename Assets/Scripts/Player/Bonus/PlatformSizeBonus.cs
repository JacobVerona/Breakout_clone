public class PlatformSizeBonus : BonusBehaviour
{
    public override BonusBase Pick (Player pickedBy)
    {
        return new PlatformSize(pickedBy.Platform);
    }
}