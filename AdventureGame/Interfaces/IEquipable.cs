using AdventureGame.Characters;

namespace AdventureGame.Interfaces
{
    interface IEquipable
    {
        public string Name { get; set; }
        public void Equip(Player player, IEquipable item);
    }
}
