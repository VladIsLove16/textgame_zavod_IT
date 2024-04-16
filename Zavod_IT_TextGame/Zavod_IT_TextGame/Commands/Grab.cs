using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame.Commands
{
    public class Grab : ICommand
    {
        public string Name { get; set; } = "Взять";
        public string Execute(GameController gameController, params string[] parametrs)
        {
            if (parametrs.Length == 0 || string.IsNullOrEmpty(parametrs[0]))
                return "Что возьмём?";
            if (GameObjectStorage.GetItem(parametrs[0]) == null)
                return "Такого предмета нет";
            Room? CurrentRoom = gameController.GameState.CurrentRoom;
            if (CurrentRoom == null) return "Вы находитесь в неизвестной комнате, сообщите об ошибке!";
            Item? item = CurrentRoom.GetItem(parametrs[0]);
            if (item == null)
                return "Такого предмета в этой комнате нет";
            try
            {
                item.Execute();
                CurrentRoom.RemoveItem(item);
                gameController.GameState.PutItem(item);
                return item.OnExecuteMessage;
            }
            catch {
                return "Ошибка! Неудачная попытка взять предмет";
            }
        }
    }
}
