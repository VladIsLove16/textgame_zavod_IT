using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame.Commands
{
    public class Eat : ICommand
    {
        public string Name { get; set; } = "Похавать";

        public string Execute(GameController gameController, params string[] parametrs)
        {
            if (!gameController.GameState.CurrentRoom.RoomState.State.ContainsKey("CanEat") || !gameController.GameState.CurrentRoom.RoomState.State["CanEat"])
                return "Здесь нельзя есть";
            if (string.IsNullOrEmpty(parametrs[0]))
                return "А что есть будем?";
            Item food = GameObjectStorage.GetItem(parametrs[0]);
            if (food == null)
                return "Я не знаю такой еды";
            return food.OnExecuteMessage;
        }
    }
}
