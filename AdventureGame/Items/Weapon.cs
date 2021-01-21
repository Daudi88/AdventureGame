using AdventureGame.Characters;
using AdventureGame.Interfaces;

namespace AdventureGame.Items
{
    class Weapon : Item, IEquipable
    {
        public string Damage { get; set; }
        public string Bonus { get; set; }

        public Weapon(string name, int cost, string damage) : base(name, cost)
        {
            Damage = damage;
            Bonus = Damage + " Damage";
        }

        public void Equip(IPlayable player, IEquipable item)
        {
            if (player.Weapon != null)
            {
                player.Backpack.Add(player.Weapon);
            }
            player.Weapon = (Weapon)item;
            player.Damage = Damage;
        }

        public override string ToString()
        {
            return $"{Name} ({Damage} Damage)";
        }
    }
}
