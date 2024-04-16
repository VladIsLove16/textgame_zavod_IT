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
            return gameController.GameState.CurrentRoom.EnterMessage;
        }
    }
}
