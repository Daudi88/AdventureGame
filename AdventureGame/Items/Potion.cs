using AdventureGame.Characters;
using AdventureGame.Interfaces;

namespace AdventureGame.Items
{
    class Potion : Item, IConsumable
    {
        public int Healing { get; set; }

        public Potion(string name, int cost, int health, int quantity) : base(name, cost)
        {
            Healing = health;
            Quantity = quantity;
        }

        public void Consume(Player player)
        {
            player.Hp += Healing;
            if (player.Hp > player.MaxHp)
            {
                player.Hp = player.MaxHp;
            }
        }
    }
}
