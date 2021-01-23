using AdventureGame.Items;
using AdventureGame.Items.Weapons;
using System.Collections.Generic;

namespace AdventureGame.Characters
{
    class Player : Character
    {
        public double Pos { get; set; } = 0.0;
        public int MaxHp { get; set; }
        public int MaxExp { get; set; }
        public List<Item> Backpack { get; set; } = new List<Item>();
        
        public Player()
        {
            MaxHp = Hp;
            MaxExp = 200 * Level;
            Weapon = new Fists();
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
