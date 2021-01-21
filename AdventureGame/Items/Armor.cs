using AdventureGame.Characters;
using AdventureGame.Interfaces;

namespace AdventureGame.Items
{
    class Armor : Item, IEquipable
    {
        public int MaxHp { get; set; }
        public string Bonus { get; set; }

        public Armor(string name, int cost, int maxHp) : base(name, cost)
        {
            MaxHp = maxHp;
            Bonus = MaxHp + " Hp";
        }

        public void Equip(IPlayable player, IEquipable item)
        {
            if (player.Armor != null)
            {
                player.Backpack.Add(player.Armor);
            }
            player.Armor = (Armor)item;
            player.MaxHp += MaxHp;

        }

        public override string ToString()
        {
            return $"{Name} (+{MaxHp} Hp)";
        }
    }
}
