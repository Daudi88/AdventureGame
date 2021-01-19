using AdventureGame.Items;
using System.Collections.Generic;

namespace AdventureGame.Interfaces
{
    interface IPlayable
    {
        public string Race { get; set; }
        public string Class { get; set; }
        public int MaxHp { get; set; }
        public int MaxExp { get; set; }
        public Armor Armor { get; set; }
        public Weapon Weapon { get; set; }
        public List<Item> Backpack { get; set; }

        public void LevelUp();
    }
}
