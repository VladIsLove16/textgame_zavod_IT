using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame.Commands
{
    public class LookAround : ICommand
    {
        public string Name { get; set; } = "Осмотреться";
        public string Execute(GameController gameController, params string[] parametrs)
        {
            Room? CurrentRoom = gameController.GameState.CurrentRoom;
            if (CurrentRoom == null) return "Вы находитесь в неизвестной комнате, сообщите об ошибке!";
            List<Item> items= CurrentRoom.GetAllItems();
            string message = "В комнате вы видите такие предметы: ";
            foreach (Item item in items) {
                message += item.Name+ " ";
            }
            message += ".";
            return message;
        }
    }
}
