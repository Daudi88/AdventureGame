using AdventureGame.Interfaces;
using System;

namespace AdventureGame.Items
{
    class Weapon : Item
    {
        public string Damage { get; set; }        

        public Weapon(string name, int cost, string damage) : base(name, cost)
        {
            Damage = damage;
        }
    }
}
