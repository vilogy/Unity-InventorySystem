namespace Assets.InventorySystem
{
    public class Weapon : Item
    {
        override public type Type { get; set; } = type.Weapon;
    }


    public enum weaponClass
    {
        Dagger,
        Sword
    }
}