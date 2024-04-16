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
            Room? CurrentRoom = gameController.GameState.CurrentRoom;
            if(CurrentRoom == null)
                return "Вы находитесь в неизвестной комнате, сообщите об ошибке!";
            if (!CurrentRoom.RoomState.State.ContainsKey("CanEat") || !CurrentRoom.RoomState.State["CanEat"])
                return "Здесь нельзя есть";
            if (parametrs.Length==0 || string.IsNullOrEmpty(parametrs[0]))
                return "А что есть будем?";

            Item? food = GameObjectStorage.GetItem(parametrs[0]);
            if (food == null)
                return "Я не знаю такой еды";
            food = CurrentRoom.GetItem(parametrs[0]);
            if (food == null)
                return "Здесь такого нет";
            if (!food.CanBeEaten)
                return "Псих! Это нельзя есть!!";
             return food.OnExecuteMessage;
        }
    }
}
