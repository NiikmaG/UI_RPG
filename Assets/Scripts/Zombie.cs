using UnityEngine;

public class Zombie : Enemy
{
    [SerializeField] private int minDamage = 5;
    [SerializeField] private int maxDamage = 12;

    public override int Attack(Character target)
    {
        int damage = Random.Range(minDamage, maxDamage + 1);
        target.TakeDamage(damage);
        return damage;
    }

    public override string UseSpecialAbility(Character target)
    {
        int damage = Random.Range(minDamage, maxDamage + 1);
        target.TakeDamage(damage, true);
        return $"{Name} uses Crushing Blow! Ignores armor! {damage} damage!";
    }
}
