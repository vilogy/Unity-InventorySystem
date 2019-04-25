using Assets.InventorySystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ItemDragHandler : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public Item draggedItem;
    SlotUI dragFrom;
    Vector3 dragFromPosition;
    SlotUI dragTo;

    Transform itemSprite;
    RectTransform itemSpriteRectTransform;

    private void Start()
    {
        itemSprite = transform.Find("Sprite");
        itemSpriteRectTransform = itemSprite.GetComponent<RectTransform>();

        dragFrom = GetComponent<SlotUI>();
        dragFromPosition = itemSpriteRectTransform.localPosition;
    }


    public void OnBeginDrag(PointerEventData eventData)
    {

        if (!dragFrom.slot.IsEmpty)
        {
            draggedItem = dragFrom.slot.Item;
            itemSprite.GetComponent<Canvas>().sortingOrder = 2;
            UIManager.instance.HideTooltip();
        }

    }

    public void OnDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {
            itemSpriteRectTransform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (draggedItem != null)
        {

            dragTo = eventData.pointerCurrentRaycast.gameObject?.GetComponent<SlotUI>();

            if (dragTo != null)
            {
                // swap items
                Item tempItem = dragTo.parentContainer.GetSlot(dragTo.slotLocation).Item;

                dragTo.parentContainer.OvverideItem(draggedItem, dragTo.slotLocation);
                dragFrom.parentContainer.OvverideItem(tempItem, dragFrom.slotLocation);

                // show tooltip
                UIManager.instance.ShowTooltip(dragTo.gameObject.transform.position, dragTo.slot.Item.Name);

                //reset dragTo;
                dragTo = null;
            }


            //return itemUI to parent position
            itemSpriteRectTransform.localPosition = dragFromPosition;
            itemSprite.GetComponent<Canvas>().sortingOrder = 1;

            draggedItem = null;
        }

    }
}
