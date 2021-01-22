using AdventureGame.Structure;
using System;

namespace AdventureGame.Characters
{
    class Enemy : Character
    {
        public Enemy(string name, int level, int hp, int defence ,string damage, int exp) : base(hp, damage)
        {
            Name = name;
            Level = level;
            Exp = exp;
            Gold = Utility.RollDice(100 * Level);
        }
    }
}
