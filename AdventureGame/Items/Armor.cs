using AdventureGame.Characters;
using AdventureGame.Interfaces;

namespace AdventureGame.Items
{
    class Armor : Item, IEquipable
    {
        public int MaxHp { get; set; }

        public Armor(string name, int cost, int maxHp) : base(name, cost)
        {
            MaxHp = maxHp;
        }

        public void Equip(Player player)
        {
            player.MaxHp += MaxHp;
        }

        public override string ToString()
        {
            return $"{Name} (+{MaxHp} Hp)";
        }
    }
}
