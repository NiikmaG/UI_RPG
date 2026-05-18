public class Staff : Weapon
{
    [UnityEngine.SerializeField] private int bonusVsUndead = 8;

    public override int CalculateDamage(Character target)
    {
        return BaseDamage + (target is Zombie ? bonusVsUndead : 0);
    }

    protected override string GetSpecialInfo()
    {
        return $"Bonus vs undead: +{bonusVsUndead}";
    }
}
