using AdventureGame.Interfaces;

namespace AdventureGame.Items
{
    class Potion : Item, IConsumable
    {
        public int Healing { get; set; }
        public string Text { get; set; }

        public Potion(string name, int cost, int health, string text) : base(name, cost)
        {
            Healing = health;
            Text = text;
        }

        public void Consume(IPlayable player)
        {
            if (true)
            {

            }
            player.Hp += Healing;
            if (player.Hp > player.MaxHp) // [HÅKAN]
            {
                player.Hp = player.MaxHp; // [HÅKAN]
            }
            System.Console.WriteLine(Text);
        }

        public override string ToString()
        {
            return $"{Quantity} {Name} (+{Healing} Hp)";
        }
    }
}
