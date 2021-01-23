using System;
using System.Collections.Generic;
using System.Text;

namespace AdventureGame.Items.Potions
{
    class RedBull : Potion
    {
        public RedBull()
        {
            Name = "Red Bull";
            Cost = 50;
            Healing = 20;
            Text = "You drink a powerfull potion that gives you wings!";
        }
    }
}
