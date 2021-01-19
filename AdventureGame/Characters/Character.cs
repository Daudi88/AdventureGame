using AdventureGame.Interfaces;
using System;
using System.Collections.Generic;

namespace AdventureGame.Creatures
{
    abstract class Character
    {
        public string Name { get; set; }
        public int Level { get; set; } = 2;
        public int Hp { get; set; }
        public int Exp { get; set; } = 0;
        public int Damage { get; set; }
        public int Gold { get; set; } = 0;

        public Character(int hp, int damage)
        {
            Hp = hp;
            Damage = damage;
        }

        public abstract int Attack();
    }
}
