using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.InventorySystem
{
    public class Slot
    {
        public Position Position { get; set; }

        bool isEmpty;
        public bool IsEmpty { get { return isEmpty; } }

        Item item;
        public Item Item
        {
            get { return item; }
            set
            {
                if (value == null)
                    isEmpty = true;
                else
                    isEmpty = false;
                item = value;
            }
        }


        /*public Slot()
        {
            isEmpty = true;
        }*/

    }
}
