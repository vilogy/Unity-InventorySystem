using UnityEngine;

namespace Assets.InventorySystem
{
    public class PlayerInventory : MonoBehaviour
    {
        Container inventory;

        void Start()
        {
            inventory = GetComponent<Container>();

            inventory.AddItem(new Dagger { Name = "Weapon", SpriteId = 0, Rarity = rarity.Magic});
            inventory.AddItem(new Dagger { Name = "Weapon 2", SpriteId = 1, Rarity = rarity.Normal });
            inventory.AddItem(new Dagger { Name = "Weapon 3", SpriteId = 2, Rarity = rarity.Rare }, new Position (2,5));
            inventory.AddItem(new Dagger { Name = "opop", SpriteId = 2, Rarity = rarity.Unique }, new Position(3, 7));
        }
    }
}