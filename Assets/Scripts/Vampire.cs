using UnityEngine;

public class Vampire : Enemy
{
    [SerializeField] private int biteDamage = 15;
    [SerializeField] private float lifesteal = 0.5f;

    public override int Attack(Character target)
    {
        target.TakeDamage(biteDamage);
        Heal(Mathf.RoundToInt(biteDamage * lifesteal));
        return biteDamage;
    }

    public override string UseSpecialAbility(Character target)
    {
        int damage = biteDamage * 2;
        target.TakeDamage(damage);
        int heal = Mathf.RoundToInt(damage * lifesteal);
        Heal(heal);
        return $"{Name} uses Blood Drain! {damage} damage, heals for {heal}!";
    }
}
