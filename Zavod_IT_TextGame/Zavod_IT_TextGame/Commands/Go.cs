using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame.Commands
{
    public class Go : ICommand
    {
        public string Name { get; set; } = "Идти";
        public string Execute(GameController gameController, params string[] parametrs)
        {
            if (string.IsNullOrEmpty(parametrs[0]))
                return "Куда?";
            Room roomToGo= GameObjectStorage.GetRoom(parametrs[0]);
            if (roomToGo == null) 
                return "Такой комнаты нет";
            if (!CanGoTo(gameController, roomToGo))
            {
                return $"Нет пути в {roomToGo.Name}";
            }
            gameController.GameState.SetRoom(roomToGo);
            return roomToGo.EnterMessage;
        }
        private bool CanGoTo(GameController controller,Room room)
        {
            return controller.GameState.CurrentRoom.AdjoiningRooms.Contains(room);
        }
    }
}
