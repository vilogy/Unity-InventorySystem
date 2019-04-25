using Assets.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SlotUI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject goItem;
    public GameObject goRarity;

    public Position slotLocation;
    public Container parentContainer;
    public Slot slot;
    public ItemDragHandler itemDragHandler;

    //Called on initalization
    public void initEvent()
    {
        goItem = transform.Find("Sprite").Find("Item").gameObject;
        goRarity = transform.Find("Sprite").Find("RarityBg").gameObject;

        parentContainer = GetComponentInParent<Container>();
        parentContainer.onSlotChange += UpdateSlotUIData;

        UpdateUI();
        //DebugUI();
    }

    //Triggered by an event
    public void UpdateSlotUIData(Slot Slot)
    {
        if (slot.Position.X == Slot.Position.X && slot.Position.Y == Slot.Position.Y)
        {
            slot = Slot;
            UpdateUI();
        }
    }

    public void UpdateUI()
    {
        if (!slot.IsEmpty)
        {

            goItem.GetComponent<Image>().sprite = ItemManager.instance.GetSprite(slot.Item);
            goItem.GetComponent<Image>().color = Color.white;

            
            switch (slot.Item.Rarity)
            {
                case rarity.Normal:
                    goRarity.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
                    break;
                case rarity.Magic:
                    goRarity.GetComponent<Image>().color = new Color(0, 0, 1, 0.2f);
                    break;
                case rarity.Rare:
                    goRarity.GetComponent<Image>().color = new Color(1, 0.92f, 0.016f, 0.2f);
                    break;
                case rarity.Unique:
                    goRarity.GetComponent<Image>().color = new Color(1, 0, 1, 0.2f);
                    break;
                default:
                    break;
            }
        }
        else
        {
            goItem.GetComponent<Image>().sprite = null;
            goItem.GetComponent<Image>().color = Color.clear;

            goRarity.GetComponent<Image>().color = Color.clear;
        }

    }

    public void DebugUI()
    {
        transform.Find("PositionLabel").GetComponent<Text>().text = $"[{slotLocation.X},{slotLocation.Y}]";
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!slot.IsEmpty && itemDragHandler.draggedItem == null)
        {
            UIManager.instance.ShowTooltip(transform.position,
                slot.Item.Name + System.Environment.NewLine + 
                "SpriteId: " + slot.Item.SpriteId + System.Environment.NewLine + 
                "Type: " + slot.Item.Type);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        UIManager.instance.HideTooltip();
    }
}
