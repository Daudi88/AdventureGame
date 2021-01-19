using AdventureGame.HelperMethods;
using System;

namespace AdventureGame.Characters
{
    class Monster : Character
    {
        public Monster(string name, int level, int hp, string damage, int exp) : base(hp, damage)
        {
            Name = name;
            Level = level;
            Exp = exp;
            Gold = Utility.RollDice(100 * Level);
        }

        public override int Attack()
        {
            int damage = Utility.RollDice(Damage);
            string text = $"{Name} hits you dealing {damage} damage!";
            Console.WriteLine($"\t┃ {text.PadRight(38)}  ┃");
            return damage;
        }
    }
}
