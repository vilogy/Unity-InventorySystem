using UnityEngine;

namespace Assets.InventorySystem
{
    public class Container : MonoBehaviour
    {
        //  init container
        public string Name;
        public int SizeX;
        public int SizeY;

        public GameObject ContainerSlot;

        //  init events
        public delegate void ContainerEventHandler(Slot slot);
        public event ContainerEventHandler onSlotChange;

        //  init slots
        Slot[,] slots;


        //  Start
        void Awake()
        {
            slots = new Slot[SizeX, SizeY];
            CleanContainer();
            CreateUI();
        }


        //  Main methods
        public bool AddItem(Item item)
        {
            Position position = GetNextEmptySlot();
            if (position != null)
            {
                slots[position.X, position.Y].Item = item;
                onSlotChange(slots[position.X, position.Y]);
                return true;
            }
            return false;
        }
        public bool AddItem(Item item, Position position)
        {
            if (slots[position.X, position.Y].IsEmpty)
            {
                slots[position.X, position.Y].Item = item;
                onSlotChange(slots[position.X, position.Y]);
                return true;
            }
            return false;
        }


        public void RemoveItem(Position position)
        {
            if (!slots[position.X, position.Y].IsEmpty)
            {
                slots[position.X, position.Y].Item = new Item();
                onSlotChange(slots[position.X, position.Y]);
            }
        }

        public void OvverideItem(Item item, Position position)
        {
            slots[position.X, position.Y].Item = item;
            onSlotChange(slots[position.X, position.Y]);
        }


        //  Helpers

        public Slot GetSlot(Position position)
        {
            return slots[position.X, position.Y];
        }

        public int CountEmptySlots()
        {
            int emptySlots = 0;

            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    if (slots[x, y].IsEmpty)
                        emptySlots++;
                }
            }

            return emptySlots;
        }
        public int CountEmptySlots(Position startFrom)
        {
            int emptySlots = 0;

            for (int x = startFrom.X; x < SizeX; x++)
            {
                for (int y = startFrom.Y; y < SizeY; y++)
                {
                    if (slots[x, y].IsEmpty)
                        emptySlots++;
                }
            }

            return emptySlots;
        }

        public Position GetNextEmptySlot()
        {
            foreach (Slot slot in slots)
            {
                if (slot.IsEmpty)
                    return new Position(slot.Position.X, slot.Position.Y);
            }

            return null;
        }
        public Position GetNextEmptySlot(Position startFrom)
        {

            foreach (Slot slot in slots)
            {
                if (slot.Position.X > startFrom.X && slot.Position.Y > startFrom.Y)
                    if (slot.IsEmpty)
                        return new Position(slot.Position.X, slot.Position.Y);
            }

            return null;
        }

        public void CleanContainer()
        {
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    slots[x, y] = new Slot();
                    slots[x, y].Position = new Position(x, y);
                    slots[x, y].Item = null;
                }
            }
        }


        void CreateUI()
        {
            for (int x = 0; x < SizeX; x++)
            {
                for (int y = 0; y < SizeY; y++)
                {
                    GameObject invSlot = Instantiate(ContainerSlot);
                    invSlot.transform.SetParent(transform,false);
                    invSlot.name = "SlotUI";
                    //invSlot.transform.localScale = Vector3.one;

                    // location
                    invSlot.GetComponent<SlotUI>().slotLocation = new Position(x, y);
                    invSlot.GetComponent<SlotUI>().slot = slots[x, y];
                    invSlot.GetComponent<SlotUI>().initEvent();

                }
            }

        }
    }
}
