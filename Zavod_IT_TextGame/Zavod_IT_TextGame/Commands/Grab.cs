using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame.Commands
{
    public class Grab
    {
        public string Name { get; set; } = "Взять";
        public string Execute(GameController gameController, params string[] parametrs)
        {
            if (string.IsNullOrEmpty(parametrs[0]))
                return "Что возьмём?";
            if (GameObjectStorage.GetItem(parametrs[0]) == null)
                return "Такого предмета нет";
            Item? item = gameController.GameState.CurrentRoom.GetItem(parametrs[0]);
            if (item == null)
                return "Такого предмета в этой комнате нет";
            try
            {
                gameController.GameState.CurrentRoom.RemoveItem(item);
                gameController.GameState.Inventory.Add(item);
                return item.OnExecuteMessage;
            }
            catch {
                return "Ошибка! Неудачная попытка взять предмет";
            }
        }
    }
}
