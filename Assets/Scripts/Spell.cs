using UnityEngine;

public abstract class Spell : MonoBehaviour
{
    [SerializeField] private string spellName = "Spell";
    [SerializeField] private string description = "";

    private bool _isActive;

    public string SpellName
    {
        get { return spellName; }
        protected set { spellName = value; }
    }

    public string Description
    {
        get { return description; }
        protected set { description = value; }
    }

    public bool IsActive
    {
        get { return _isActive; }
        protected set { _isActive = value; }
    }

    public abstract string Cast(Player caster, Character target = null);

    public string GetInfo()
    {
        return $"{spellName}: {description}";
    }
}
