using AdventureGame.Interfaces;
using System;
using System.Collections.Generic;

namespace AdventureGame.Creatures
{
    abstract class Creature : IMentionable, IDamageble
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public int ArmorClass { get; set; }
        public int HitPoints { get; set; }
        public int ExperiencePoints { get; set; }
        public int Gold { get; set; }
        public abstract void Attack(Creature defender);
    }
}
