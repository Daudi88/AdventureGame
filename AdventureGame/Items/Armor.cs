using AdventureGame.Interfaces;
using System;

namespace AdventureGame.Items
{

    // HÅKAN TODO
    // En attack ska returnera damage - defender.Armor.
    // En Armor ska inte ge +Hp utan armor
    // Details ska visa => Armor: Flak Jacket (5)
    // Uppdatera de armors som redan finns så att de ger en balanserad armor
    class Armor : Item, IEquipable // [HÅKAN]
    {
        public int Defence { get; set; } // Heta Defence
       

        public Armor(string name, int cost, int defence) : base(name, cost) // int maxHp måste bytas till defence KLAR
        {
            Defence = defence ; // defence = defence KLAR
        }

        public void Equip(IPlayable player, IEquipable item)
        {
            if (player.Armor != null)
            {
                player.Backpack.Add(player.Armor);
            }
            Console.WriteLine($"\t you equipped {item.Name} and gained {Defence} defence!");
            player.Armor = (Armor)item;
            player.Defence = Defence;

        }

        public override string ToString()
        {
            return $"{Name} (+{Defence} Hp)";
        }
    }
}
