using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private string weaponName = "Weapon";
    [SerializeField] private int baseDamage = 10;
    [SerializeField] private string weaponType = "Physical";

    public string Name
    {
        get { return weaponName; }
        protected set { weaponName = value; }
    }

    public int BaseDamage
    {
        get { return baseDamage; }
        protected set { baseDamage = value < 0 ? 0 : value; }
    }

    public string WeaponType
    {
        get { return weaponType; }
        protected set { weaponType = value; }
    }

    public virtual bool IgnoresDefense => false;

    public abstract int CalculateDamage(Character target);

    public string GetDescription()
    {
        return $"{weaponName} ({weaponType}) - {baseDamage} dmg";
    }

    public string GetDescription(bool detailed)
    {
        if (detailed)
            return $"{weaponName}\nType: {weaponType}\nBase damage: {baseDamage}\n{GetSpecialInfo()}";
        return GetDescription();
    }

    protected virtual string GetSpecialInfo() => "";
}
