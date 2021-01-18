namespace AdventureGame.Interfaces
{
    /// <summary>
    /// Interface for equipable items.
    /// </summary>
    interface IEquipable
    {        
        public int AbilityModifier { get; set; }
        public string ModifierName { get; set; }
    }
}
