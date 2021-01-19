using AdventureGame.Interfaces;

namespace AdventureGame.Items
{
    abstract class Item : IStackable
    {
        public string Name { get; set; }

        /// <summary>
        /// Cost in gold.
        /// </summary>
        public double Cost { get; set; }
        public int Quantity { get; set; } = 1;

        public Item(string name, int cost)
        {
            Name = name;
            Cost = cost;
        }
    }
}
