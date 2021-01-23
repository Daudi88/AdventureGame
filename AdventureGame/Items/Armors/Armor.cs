using AdventureGame.Interfaces;
using AdventureGame.Characters;
using System;

namespace AdventureGame.Items.Armors
{
    abstract class Armor : Item, IEquipable
    {
        public int Defence { get; set; }

        public void Equip(Player player, IEquipable item)
        {
            if (player.Armor != null)
            {
                player.Backpack.Add(player.Armor);
            }
            Console.WriteLine($"\t you equipped {item.Name} with {Defence} defence!");
            player.Armor = (Armor)item;
            player.Defence = Defence;
        }

        public override string ToString()
        {
            return $"{Name} ({Defence} Defence)";
        }
    }
}
