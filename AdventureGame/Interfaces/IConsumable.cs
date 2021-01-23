using AdventureGame.Characters;

namespace AdventureGame.Interfaces
{
    /// <summary>
    /// Interface for consumable items.
    /// </summary>
    interface IConsumable
    {
        /// <summary>
        /// How much the item heals its user.
        /// </summary>
        public int Healing { get; set; }
        public string Text { get; set; }
        public void Consume(Player player);
    }
}
