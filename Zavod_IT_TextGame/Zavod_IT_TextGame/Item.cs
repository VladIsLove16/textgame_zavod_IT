using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public class Item : GameObject
    {
        public bool CanBeEaten=false;//надо создавать интерфейс IEatable и для всех съедобных объектов наследоваться от него, но времени у меня не осталось и для разных других свойств тоже
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
        public void Execute()
        {
            OnExecute?.Invoke(OnExecuteMessage);
        }

        public delegate void ItemHandler(string message);
        public event ItemHandler? OnExecute;

    }
}
