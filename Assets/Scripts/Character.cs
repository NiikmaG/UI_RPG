using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private string charName = "Character";
    [SerializeField] private int maxHp = 100;
    [SerializeField] private int defense = 0;

    private int _hp;

    public string Name
    {
        get { return charName; }
        protected set { charName = value; }
    }

    public int MaxHp
    {
        get { return maxHp; }
        protected set { maxHp = value < 1 ? 1 : value; }
    }

    public int Hp
    {
        get { return _hp; }
        protected set { _hp = value < 0 ? 0 : (value > maxHp ? maxHp : value); }
    }

    public int Defense
    {
        get { return defense; }
        protected set { defense = value < 0 ? 0 : value; }
    }

    public bool IsAlive => _hp > 0;

    protected virtual void Awake()
    {
        _hp = maxHp;
    }

    public abstract int Attack(Character target);

    public virtual void TakeDamage(int damage)
    {
        int actual = damage - defense;
        Hp -= actual < 1 ? 1 : actual;
    }

    public virtual void TakeDamage(int damage, bool ignoreDefense)
    {
        if (ignoreDefense)
            Hp -= damage < 0 ? 0 : damage;
        else
            TakeDamage(damage);
    }

    public virtual void Heal(int amount)
    {
        Hp += amount;
    }

    public void ResetHp()
    {
        _hp = maxHp;
    }
}
