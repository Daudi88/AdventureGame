using AdventureGame.HelperMethods;
using AdventureGame.Creatures;
using System;

namespace AdventureGame.Creatures.Monsters
{
    class Bugbear : Creature
    {
        public Bugbear()
        {
            Name = "Bugbear";
            Level = 1;
            ArmorClass = 16;
            HitPoints = Utility.RollDice("5d8") + 5;
            ExperiencePoints = 200;
        }
        public void Morningstar(Player player)
        {
            
        }

        public void Javelin(Player player)
        {
            Console.WriteLine($"The bugbear tries to hit you with its Javelin!");
            Console.ReadKey(true);
            if (Utility.RollDice("1d20") + 4 >= player.ArmorClass)
            {
                int damage = Utility.RollDice("2d6") + 2;
                Console.WriteLine($"The bugbear hits you, dealing {damage} damage!");
                player.HitPoints -= damage;
            }
            else
            {
                Console.WriteLine($"The bugbear missed.");
            }
            Console.ReadKey(true);
        }

        public override void Attack(Creature defender)
        {
            Console.WriteLine($"The bugbear tries to hit you with its Morningstar!");
            Console.ReadKey(true);
            if (Utility.RollDice("1d20") + 4 >= defender.ArmorClass)
            {
                int damage = Utility.RollDice("2d8") + 2;
                Console.WriteLine($"The bugbear hits you, dealing {damage} damage!");
                defender.HitPoints -= damage;
            }
            else
            {
                Console.WriteLine($"The bugbear missed.");
            }
            Console.ReadKey(true);
        }
    }
}
