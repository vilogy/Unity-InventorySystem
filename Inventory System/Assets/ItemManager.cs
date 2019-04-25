using Assets.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] Sprite[] WeaponSprites;

    public static ItemManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    public Sprite GetSprite(Item item)
    {
        switch (item.Type)
        {
            case type.Weapon:
                return WeaponSprites[item.SpriteId];
            default:
                return null;
        }
        
    }
}
