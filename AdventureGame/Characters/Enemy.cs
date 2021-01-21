﻿using AdventureGame.HelperMethods;
using System;

namespace AdventureGame.Characters
{
    class Enemy : Character
    {
        public Enemy(string name, int level, int hp, string damage, int exp) : base(hp, damage)
        {
            Name = name;
            Level = level;
            Exp = exp;
            Gold = Utility.RollDice(100 * Level);
        }

        public override int Attack()
        {
            return Utility.RollDice(Damage);
        }
    }
}
