using AdventureGame.Interfaces;
using System;
using System.Collections.Generic;

namespace AdventureGame.Creatures
{
    abstract class Character
    {
        public string Name { get; set; } = "";
        public int Level { get; set; } = 1;
        public int Hp { get; set; } = 0;
        public int Exp { get; set; } = 0;
        public int Strength { get; set; } = 0;
        public int Gold { get; set; } = 0;

        public Character(int hp, int strength)
        {
            Hp = hp;
            Strength = strength;
        }

        public abstract int Attack();
    }
}
