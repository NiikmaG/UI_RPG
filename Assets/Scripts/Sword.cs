using UnityEngine;

public class Sword : Weapon
{
    [SerializeField] private int critChance = 25;

    public override int CalculateDamage(Character target)
    {
        bool crit = Random.Range(0, 100) < critChance;
        return crit ? BaseDamage * 2 : BaseDamage;
    }

    protected override string GetSpecialInfo()
    {
        return $"Crit chance: {critChance}%";
    }
}
