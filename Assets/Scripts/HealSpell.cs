public class HealSpell : Spell
{
    [UnityEngine.SerializeField] private int healAmount = 20;

    public override string Cast(Player caster, Character target = null)
    {
        caster.Heal(healAmount);
        return $"{caster.Name} casts Heal and recovers {healAmount} HP!";
    }
}
