using UnityEngine;

public abstract class Enemy : Character
{
    [SerializeField] private int expReward = 30;
    [SerializeField] private string attackName = "Attack";

    public int ExpReward
    {
        get { return expReward; }
        protected set { expReward = value < 0 ? 0 : value; }
    }

    public string AttackName
    {
        get { return attackName; }
        protected set { attackName = value; }
    }

    public abstract override int Attack(Character target);

    public virtual string UseSpecialAbility(Character target)
    {
        return $"{Name} has no special ability.";
    }
}
