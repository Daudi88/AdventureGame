using AdventureGame.Interfaces;
using System;

namespace AdventureGame.Items
{
    class Weapon : Item, IEquipable
    {
        public string Damage { get; set; }
        public int AbilityModifier { get; set; }
        public string ModifierName { get; set; }

        public Weapon(string name, int cost, int weight, string damage, int abilityModifier, string modifierName) : base(name, cost, weight)
        {
            Damage = damage;
            AbilityModifier = abilityModifier;
            ModifierName = modifierName;
        }

        public override void Describe()
        {
            Console.WriteLine($"{Name}\t{Cost} gp\t{Damage}\t{Weight}");
        }
    }
}
