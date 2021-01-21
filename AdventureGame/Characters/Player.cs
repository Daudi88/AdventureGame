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
        public Armor Armor { get; set; }
        public Weapon Weapon { get; set; }
        public List<Item> Backpack { get; set; } = new List<Item>();

        public Player(int hp, string damage) : base(hp, damage)
        {
            MaxHp = Hp;
            MaxExp = 200 * Level; // Fundera på om denna ska ligga i en variabel/metod eftersom vi använder den på flera ställen. 
        }

        public override int Attack(out string text)
        {
            int damage = Utility.RollDice(Damage);
            text = $"You hit the monster with your {Weapon.Name} dealing {damage} damage!";
            //Console.WriteLine($"\t┃ {text.PadRight(39)}  ┃");
            return damage;
        }

        public void LevelUp()
        {
            Level++;
            MaxExp += 200 * Level;
            MaxHp += Level;
            if (MaxHp > 1000)
            {
                MaxHp = 1000;
            }
            Hp = MaxHp;
        }
    }
}
