using AdventureGame.Characters;
using AdventureGame.Interfaces;

namespace AdventureGame.Items
{
    class Weapon : Item, IEquipable
    {
        public string Damage { get; set; }

        public Weapon(string name, int cost, string damage) : base(name, cost)
        {
            Damage = damage;
        }

        public void Equip(Player player)
        {
            player.Damage = Damage;
        }

        public override string ToString()
        {
            return $"{Name} ({Damage} Damage)";
        }
    }
}
