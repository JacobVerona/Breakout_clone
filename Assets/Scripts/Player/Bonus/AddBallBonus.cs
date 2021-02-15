public class AddBallBonus : BonusBehaviour
{
    public override BonusBase Pick (Player pickedBy)
    {
        return new AddBall(pickedBy);
    }
}
