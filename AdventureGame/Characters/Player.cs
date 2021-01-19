using AdventureGame.HelperMethods;
using AdventureGame.Interfaces;
using AdventureGame.Items;
using System;
using System.Collections.Generic;

namespace AdventureGame.Creatures
{
    class Player : Character, IPlayable
    {
        public string Race { get; set; }
        public string Class { get; set; }
        public int MaxHp { get; set; }
        public int MaxExp { get; set; }

        public Player(int hp, int strength) : base(hp, strength)
        {
            MaxHp = Hp;
            MaxExp = 200 * Level; // Fundera på om denna ska ligga i en variabel/metod eftersom vi använder den på flera ställen. 
        }

        public override int Attack()
        {
            int damage = Utility.RollDice(Strength * 2);
            Console.WriteLine($"\tYou hit the monster dealing {damage} damage!");
            return damage;
        }

        public void LevelUp()
        {
            Exp = Exp - MaxExp; // Kom på ett snyggare sätt att skriva detta på! ;)
            Level++;
            MaxExp += 200 * Level;
            MaxHp += Level;
            Hp = MaxHp;
            Strength++;
        }
    }
}
