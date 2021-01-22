using AdventureGame.Interfaces;
using AdventureGame.Characters;
using System;

namespace AdventureGame.Items
{
    class Weapon : Item, IEquipable
    {
        public string Damage { get; set; }

        public Weapon(string name, int cost, string damage) : base(name, cost)
        {
            Damage = damage;
        }

        public void Equip(Player player, IEquipable weapon)
        {
            if (player.Weapon != null)
            {
                player.Backpack.Add(player.Weapon);
            }
            Console.WriteLine($"\t you equipped {Name} and gained {Damage} Damage!");
            player.Weapon = (Weapon)weapon;
            player.Damage = Damage;
        }

        public override string ToString()
        {
            return $"{Name} ({Damage} Damage)";
        }
    }
}
