# UI RPG - Ņikita Magamedgadžijevs

## Par projektu

Šis ir Unity spēle, kurā spēlētājs cīnās pret pretiniekiem caur UI pogām. Spēle ir izveidota izmantojot 4 OOP principus.

## Kā spēlēt

- Nospied **Attack zombie** lai uzbruktu pretiniekam
- Pēc uzbrukuma pretinieks automātiski uzbrūk atpakaļ
- Ja pretinieks nomirst - parādās jauns
- Ja spēlētājs nomirst - spēle beidzas, var restartēt

---

## OOP principi

### 1. Mantošana
Izveidoju bāzes klasi `Character`, no kuras manto gan `Player`, gan `Enemy`. `Enemy` arī ir abstrakts un no tā manto `Zombie` un `Vampire`. Tāpat `Weapon` ir bāze `Sword`, `Staff`, `Bow` klasēm, un `Spell` - `HealSpell` un `ShieldSpell` klasēm.

### 2. Enkapsulācija
Visi lauki klasēs ir `private`, un piekļuve tiem notiek caur `get`/`set` properties. Piemēram, `CurrentHp` automātiski ierobežo vērtību starp 0 un `MaxHp`.

### 3. Polimorfisms
Izmantoju gan **override**, gan **overload**:
- `Attack()` metode ir pārrakstīta katrā klasē savādāk
- `TakeDamage(int damage)` un `TakeDamage(int damage, bool ignoreDefense)` - overload piemērs
- `GetDescription()` un `GetDescription(bool detailed)` - vēl viens overload

### 4. Abstrakcija
`Weapon` ir abstrakta klase ar abstraktu metodi `CalculateDamage()` un parasto metodi `GetDescription()`. No šīs klases manto `Sword`, `Staff` un `Bow`. Tāpat `Character` satur abstraktu `Attack()` metodi.

---

## Papildus uzdevumi

- **2 dažādi pretinieki** - Zombie (fiziski uzbrukumi) un Vampire (dzīvības zādzība)
- **3 ieroču veidi** - Sword (kritiskais sitiens), Staff (bonuss pret nedzīvajiem), Bow (ignorē aizsardzību)
- **Līmeņu sistēma** - spēlētājs iegūst XP un paaugstina līmeni
- **Burvības** - Heal (atjauno HP) un Protect HP (vairogs)

## Bonuss

- Skaņas efekti
- Pretinieku attēli ar fade-in animāciju
- Fona attēls
