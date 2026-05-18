using UnityEngine;

public class Bow : Weapon
{
    public override bool IgnoresDefense => true;

    public override int CalculateDamage(Character target)
    {
        return BaseDamage + Random.Range(0, 6);
    }

    protected override string GetSpecialInfo()
    {
        return "Ignores enemy defense";
    }
}
