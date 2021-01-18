using AdventureGame.Interfaces;

namespace AdventureGame.Items
{
    abstract class Item : IMentionable, IDescribable
    {
        public string Name { get; set; }

        /// <summary>
        /// Cost in gold pieces (gp).
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Weight in punds (lb).
        /// </summary>
        public double Weight { get; set; }
        public int Quantity { get; set; } = 1;

        public Item(string name, int cost, int weight)
        {
            Name = name;
            Cost = cost;
            Weight = weight;
        }

        public abstract void Describe();
    }
}
