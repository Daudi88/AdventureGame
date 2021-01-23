using AdventureGame.Interfaces;
using AdventureGame.Items;
using System;
using System.Collections.Generic;

namespace AdventureGame.Characters
{
    class Player : Character
    {
        public double Pos { get; set; } = 0.0;
        public int MaxHp { get; set; }
        public int MaxExp { get; set; }
        public List<Item> Backpack { get; set; } = new List<Item>();
        
        public Player(int hp, Weapon weapon) : base(hp, weapon)
        {
            MaxHp = Hp;
            MaxExp = 200 * Level;
            Weapon = weapon;
            Damage = weapon.Damage;
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
