# UI RPG - Nikita Magamedgadzijevs

## About the project

This is a Unity game where the player fights enemies through UI buttons. 
The game was made using 4 OOP principles.

## How to play

- Press **Attack zombie** to attack the enemy
- After the attack the enemy automatically attacks back
- If the enemy dies - a new one appears
- If the player dies - game over, you can restart

---

## OOP Principles

### 1. Inheritance
I created a base class `Character`, which is inherited by both `Player` and `Enemy`. 
`Enemy` is also abstract and is inherited by `Zombie` and `Vampire`. 
Similarly `Weapon` is the base for `Sword`, `Staff`, `Bow`, and `Spell` is the base for `HealSpell` and `ShieldSpell`.

### 2. Encapsulation
All fields in the classes are `private`, and access to them is done through `get`/`set` properties. 
For example, `CurrentHp` automatically clamps the value between 0 and `MaxHp`.

### 3. Polymorphism
I used both **override** and **overload**:
- `Attack()` method is overridden differently in each class
- `TakeDamage(int damage)` and `TakeDamage(int damage, bool ignoreDefense)` - overload example
- `GetDescription()` and `GetDescription(bool detailed)` - another overload

### 4. Abstraction
`Weapon` is an abstract class with an abstract method `CalculateDamage()` and a regular method `GetDescription()`. 
`Sword`, `Staff` and `Bow` inherit from it. 
`Character` also contains an abstract `Attack()` method.

---

## Bonus tasks

- **2 different enemies** - Zombie (physical attacks) and Vampire (life steal)
- **3 weapon types** - Sword (critical hit), Staff (bonus vs undead), Bow (ignores defense)
- **Level system** - player gains XP and levels up
- **Spells** - Heal (restores HP) and Protect HP (shield)

## Extras

- Sound effects
- Enemy images with fade-in animation
- Background image
