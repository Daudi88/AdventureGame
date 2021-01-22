using System;
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
            if (player.Hp < player.MaxHp)
            {
                player.Hp += Healing;
                Console.WriteLine($"\t {Text}");
                if (player.Hp >= player.MaxHp)
                {
                    player.Hp = player.MaxHp;
                    Console.WriteLine("\t You gained full health!");
                }
                else
                {
                    Console.WriteLine("\t You gained {Health} health!");
                }                
            }
        }

        public override string ToString()
        {
            return $"{Quantity} {Name} (+{Healing} Hp)";
        }
    }
}
