using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public class Item
    {
        public string Name { get; set; } = "ItemBase";
        public string OnGrabMessage = "OnGrabMessage";
        public Item(string name)
        {
            Name = name;
        }
        public Item(string name, string? onGrabMessage)
        {
            Name = name;
            OnGrabMessage = onGrabMessage??"";
        }
        public Item Grab()
        {
            OnGrab?.Invoke(OnGrabMessage);
            return this;
        }

        delegate void ItemHandler(string message);
        event ItemHandler? OnGrab;

    }
}
