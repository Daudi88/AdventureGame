using AdventureGame.HelperMethods;
using System;

namespace AdventureGame.Characters
{
    class Enemy : Character
    {
        public Enemy(string name, int level, int hp, string damage, int exp) : base(hp, damage)
        {
            Name = name;
            Level = level;
            Exp = exp;
            Gold = Utility.RollDice(100 * Level);
        }

        public override int Attack(out string text)
        {
            int damage = Utility.RollDice(Damage);
            text = $"{Name} hits you dealing {damage} damage!";            
            return damage;
        }
    }
}
