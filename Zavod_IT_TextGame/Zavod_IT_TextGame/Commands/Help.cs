using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame.Commands
{
    internal class Help : ICommand
    {
        public string Name { get; set; } = "Помощь";

        public string Execute(GameController gameController, params string[] parametrs)
        {
            ICommand[] commands=  GameObjectStorage.GetAllCommands();
            string answer = "Доступные действия: \n";
            foreach (var command in commands)
            {
                answer.Concat("- "+command.Name+"\n");
            }
            return answer;
        }
    }
}
