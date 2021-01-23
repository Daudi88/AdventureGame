using AdventureGame.Interfaces;
using AdventureGame.Characters;
using System;

namespace AdventureGame.Items.Weapons
{
    class Weapon : Item, IEquipable
    {
        public string Damage { get; set; }

        public void Equip(Player player, IEquipable weapon)
        {
            if (player.Weapon != null)
            {
                player.Backpack.Add(player.Weapon);
            }
            Console.WriteLine($"\t you equipped {Name} with {Damage} Damage!");
            player.Weapon = (Weapon)weapon;
            player.Damage = Damage;
        }

        public override string ToString()
        {
            return $"{Name} ({Damage} Damage)";
        }
    }
}
