using AdventureGame.Creatures;

namespace AdventureGame.Interfaces
{
    /// <summary>
    /// Interface for consumable items.
    /// </summary>
    interface IConsumable
    {
        /// <summary>
        /// How much the consumable item heals its user.
        /// </summary>
        public string HitPoints { get; set; }
        public int ExtraHealing { get; set; }
        public void Consume(Creature user);
    }
}
