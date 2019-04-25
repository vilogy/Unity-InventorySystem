using Random = UnityEngine.Random;

namespace Assets.InventorySystem
{
    public class Item
    {
        public int Id { get;}
        public int SpriteId { get; set; } = 0;
        public string Name { get; set; } = "Unnamed Item";

        virtual public type Type { get; set; }
        public rarity Rarity { get; set; }

        public Item()
        {
            Id = (int)(Random.value * 10);
        }
    }

    public enum type
    {
        Weapon,
        Armour
    }

    public enum rarity
    {
        Normal,
        Magic,
        Rare,
        Unique
    }
}
