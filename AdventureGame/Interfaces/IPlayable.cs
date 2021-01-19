using AdventureGame.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Interfaces
{
    interface IPlayable
    {
        public string Race { get; set; }
        public string Class { get; set; }
        public int MaxHp { get; set; }
        public int MaxExp { get; set; }
        public Weapon Weapon { get; set; }
        public Armor Armor { get; set; }
        public List<Item> Backpack { get; set; }

        public void LevelUp();
    }
}
