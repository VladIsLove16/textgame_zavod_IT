using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public class Item : GameObject
    {
        public string Name { get; set; } = "ItemBase";
        public string OnExecuteMessage = "OnExecuteMessage";
        public Item(string name)
        {
            Name = name;
        }
        public Item(string name, string? onExecuteMessage)
        {
            Name = name;
            OnExecuteMessage = onExecuteMessage??"";
        }
        public Item Grab()
        {
            OnExecute?.Invoke(OnExecuteMessage);
            return this;
        }

        public delegate void ItemHandler(string message);
        public event ItemHandler? OnExecute;

    }
}
