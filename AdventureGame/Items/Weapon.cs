using AdventureGame.Characters;
using AdventureGame.Interfaces;
using System;

namespace AdventureGame.Items
{
    class Weapon : Item, IEquipable
    {
        public int Damage { get; set; }        

        public Weapon(string name, int cost, int damage) : base(name, cost)
        {
            Damage = damage;
        }

        public void Equip(Player player)
        {
            player.Damage = Damage;
        }
    }
}
