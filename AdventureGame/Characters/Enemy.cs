using AdventureGame.Items;
using AdventureGame.Structure;
using System;

namespace AdventureGame.Characters
{
    class Enemy : Character
    {        
        public Enemy(string name, int level, int hp, Armor armor, Weapon weapon, int exp) : base(hp, weapon)
        {
            Name = name;
            Level = level;
            Armor = armor;
            Defence = armor.Defence;
            Weapon = weapon;
            Damage = weapon.Damage;
            Exp = exp;
            Gold = Utility.RollDice(100 * level);
        }
    }
}
