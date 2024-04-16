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
            List<string> commands=  GameObjectStorage.GetAllCommands();
            int CommandCount = commands.Count;
            string answer = $"Доступные действия: {CommandCount} \n";
            Console.WriteLine(answer);
           
            for (int i = 0; i < CommandCount;i++)
            {
                answer += "- "+ commands[i]+"\n";
            }
            return answer;
        }
    }
}
