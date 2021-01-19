using AdventureGame.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Interfaces
{
    interface IPlayable
    {
        interface IPlayable
        {
            string Race { get; set; }
            string Class { get; set; }
            int MaxHp { get; set; }
            int MaxExp { get; set; }
            Weapon Weapon { get; set; }
            List<Armor> Armor { get; set; }
            List<Item> Backpack { get; set; }

            public void LevelUp();            
        }
    }
}
