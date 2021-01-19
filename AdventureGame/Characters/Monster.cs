using AdventureGame.Creatures;
using AdventureGame.HelperMethods;
using System;

namespace AdventureGame.Characters
{
    class Monster : Character
    {
        public Monster(string name, int level, int hp, int strength, int exp) : base(hp, strength)
        {
            Name = name;
            Level = level;
            Exp = exp;
            Gold = Utility.RollDice(100 * Level);
        }

        public override int Attack()
        {
            int damage = Utility.RollDice(Strength * 2);
            string text = $"{Name} hits you dealing {damage} damage!";
            Console.WriteLine($"       ┃ {text.PadRight(38 - text.Length)} ┃");
            return damage;
        }
    }
}
