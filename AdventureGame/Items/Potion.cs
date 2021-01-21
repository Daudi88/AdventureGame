using AdventureGame.Interfaces;

namespace AdventureGame.Items
{
    class Potion : Item, IConsumable
    {
        public int Healing { get; set; }

        public Potion(string name, int cost, int health) : base(name, cost)
        {
            Healing = health;
        }

        public void Consume(IPlayable player)
        {
            player.Hp += Healing;
            if (player.Hp > player.MaxHp)
            {
                player.Hp = player.MaxHp;
            }
        }

        public override string ToString()
        {
            return $"{Quantity} {Name} (+{Healing} Hp)";
        }
    }
}
