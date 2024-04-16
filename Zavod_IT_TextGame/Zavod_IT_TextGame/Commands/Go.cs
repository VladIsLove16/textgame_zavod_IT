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
            Room? CurrentRoom = gameController.GameState.CurrentRoom;
            if (CurrentRoom == null) return "Вы находитесь в неизвестной комнате, сообщите об ошибке!";
            if (parametrs.Length == 0 || string.IsNullOrEmpty(parametrs[0]))
                return "Куда?";
            Room? roomToGo= GameObjectStorage.GetRoom(parametrs[0]);
            if (roomToGo == null) 
                return "Такой комнаты нет";
            if (!CanGoTo(CurrentRoom, roomToGo))
            {
                return $"Нет пути в {roomToGo.Name}";
            }
            gameController.GameState.SetRoom(roomToGo);
            return roomToGo.EnterMessage;
        }
        private bool CanGoTo(Room fromRoom, Room roomTo)
        {
            return fromRoom.AdjoiningRooms.Contains(roomTo);
        }
    }
}
