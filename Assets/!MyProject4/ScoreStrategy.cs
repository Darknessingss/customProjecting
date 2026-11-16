public class ScoreStrategy : BaseStrategy
{
    protected override int Amount => 15;
    protected override void ApplyEffect(Model model) => model.AddScore(Amount);
}