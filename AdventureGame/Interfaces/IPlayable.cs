using AdventureGame.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Interfaces
{
    interface IPlayable
    {
        string Class { get; set; }
        string Race { get; set; }
        int MaxHp { get; set; }
        string HitDie { get; set; }
        int MaxExp { get; set; }

        int Strength { get; set; }
        int Dexterity { get; set; }
        int Constitution { get; set; }
        int Intelligence { get; set; }
        int Wisdom { get; set; }
        int Charisma { get; set; }

        int ProficiencyBonus { get; set; }
        Weapon Weapon { get; set; }
        List<Armor> Armor { get; set; }
        List<Item> Backpack { get; set; }


    }
}
