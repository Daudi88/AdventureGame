using System;
using AdventureGame.Interfaces;
using AdventureGame.Characters;

namespace AdventureGame.Items.Potions
{
    class Potion : Item, IConsumable
    {
        public int Healing { get; set; }
        public string Text { get; set; }

        public void Consume(Player player)
        {
            Console.WriteLine($"\t {Text}");
            if (player.Hp < player.MaxHp)
            {
                player.Hp += Healing;
                if (player.Hp >= player.MaxHp)
                {
                    player.Hp = player.MaxHp;
                    Console.WriteLine("\t You gained full health!");
                }
                else
                {
                    Console.WriteLine($"\t You gained {Healing} health!");
                }
            }
        }

        public override string ToString()
        {
            return $"{Quantity} {Name} (+{Healing} Hp)";
        }
    }
}
