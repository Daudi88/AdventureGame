using AdventureGame.Interfaces;
using System;

namespace AdventureGame.Items
{
    class Armor : Item
    {
        public int MaxHp { get; set; }

        public Armor(string name, int cost, int maxHp) : base(name, cost)
        {
            MaxHp = maxHp;
        }
    }
}
