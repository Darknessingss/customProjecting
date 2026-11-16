public class DamageStrategy : BaseStrategy
{
    protected override int Amount => 10;
    protected override void ApplyEffect(Model model) => model.ApplyDamage(Amount);
}