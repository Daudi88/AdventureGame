using AdventureGame.HelperMethods;
using AdventureGame.Interfaces;
using AdventureGame.Items;
using System;
using System.Collections.Generic;

namespace AdventureGame.Characters
{
    class Player : Character, IPlayable
    {
        public string Race { get; set; }
        public string Class { get; set; }
        public int MaxHp { get; set; }
        public int MaxExp { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public List<Item> Backpack { get; set; }

        public Player(int hp, int damage) : base(hp, damage)
        {
            MaxHp = Hp;
            MaxExp = 200 * Level; // Fundera på om denna ska ligga i en variabel/metod eftersom vi använder den på flera ställen. 
        }

        public override int Attack()
        {
            int damage = Utility.RollDice(Damage * 2);
            string text = $"You hit the monster dealing {damage} damage!";
            Console.WriteLine($"\t┃ {text.PadRight(38)} ┃");
            return damage;
        }

        public void LevelUp()
        {
            Level++;
            MaxExp += 200 * Level;
            MaxHp += Level;
            Hp = MaxHp;
            Damage++;
        }
    }
}
