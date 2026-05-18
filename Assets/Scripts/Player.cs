using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [SerializeField] private Sword sword;
    [SerializeField] private Staff staff;
    [SerializeField] private Bow bow;
    [SerializeField] private HealSpell healSpell;
    [SerializeField] private ShieldSpell shieldSpell;

    private Weapon _weapon;
    private int _level = 1;
    private int _exp = 0;
    private int _expToNextLevel = 100;
    private bool _shieldOn = false;
    private int _shieldHp = 0;
    private int _maxShieldHp = 30;

    public Weapon Weapon
    {
        get { return _weapon; }
        private set { _weapon = value; }
    }

    public int Level
    {
        get { return _level; }
        private set { _level = value < 1 ? 1 : value; }
    }

    public int Exp
    {
        get { return _exp; }
        private set { _exp = value; }
    }

    public int ExpToNextLevel => _expToNextLevel;
    public bool ShieldOn { get { return _shieldOn; } private set { _shieldOn = value; } }

    public int ShieldHp
    {
        get { return _shieldHp; }
        private set { _shieldHp = value < 0 ? 0 : (value > _maxShieldHp ? _maxShieldHp : value); }
    }

    public int MaxShieldHp => _maxShieldHp;
    public List<Spell> Spells { get; private set; }

    protected override void Awake()
    {
        base.Awake();
        Spells = new List<Spell>();
        if (healSpell) Spells.Add(healSpell);
        if (shieldSpell) Spells.Add(shieldSpell);
        _weapon = sword;
    }

    public override int Attack(Character target)
    {
        int damage = _weapon != null ? _weapon.CalculateDamage(target) : 5 + _level;

        if (_weapon != null && _weapon.IgnoresDefense)
            target.TakeDamage(damage, true);
        else
            target.TakeDamage(damage);

        return damage;
    }

    public override void TakeDamage(int damage)
    {
        if (_shieldOn && _shieldHp > 0)
        {
            int leftover = damage - _shieldHp;
            ShieldHp -= damage;
            if (_shieldHp <= 0)
            {
                _shieldOn = false;
                if (leftover > 0)
                    base.TakeDamage(leftover);
            }
        }
        else
        {
            base.TakeDamage(damage);
        }
    }

    public void EquipSword() { if (sword) _weapon = sword; }
    public void EquipStaff() { if (staff) _weapon = staff; }
    public void EquipBow()   { if (bow)   _weapon = bow;   }

    public void ToggleShield()
    {
        if (_shieldOn)
        {
            _shieldOn = false;
        }
        else
        {
            _shieldOn = true;
            if (_shieldHp <= 0) _shieldHp = _maxShieldHp;
        }
    }

    public void RepairShield()
    {
        _shieldHp = _maxShieldHp;
        _shieldOn = true;
    }

    public string CastSpell(int index, Character target = null)
    {
        if (index >= 0 && index < Spells.Count)
            return Spells[index].Cast(this, target);
        return "No spell in that slot.";
    }

    public void GainExp(int amount)
    {
        _exp += amount;
        while (_exp >= _expToNextLevel)
            LevelUp();
    }

    private void LevelUp()
    {
        _exp -= _expToNextLevel;
        _level++;
        _expToNextLevel = _level * 100;
        MaxHp += 10;
        Hp = MaxHp;
        Defense += 1;
    }

    public void ResetStats()
    {
        _level = 1;
        _exp = 0;
        _expToNextLevel = 100;
        _shieldOn = false;
        _shieldHp = 0;
        ResetHp();
        EquipSword();
    }
}
