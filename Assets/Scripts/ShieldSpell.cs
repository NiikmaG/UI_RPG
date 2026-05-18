public class ShieldSpell : Spell
{
    public override string Cast(Player caster, Character target = null)
    {
        caster.ToggleShield();
        IsActive = caster.ShieldOn;
        return caster.ShieldOn ? "Shield activated!" : "Shield deactivated!";
    }
}
