using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets
{
    class ToggleActive : MonoBehaviour
    {
        public void ToggleObjectActive()
        {
            gameObject.SetActive(!gameObject.activeSelf);
        }
    }
}
