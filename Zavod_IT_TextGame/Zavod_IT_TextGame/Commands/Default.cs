using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame.Commands
{
    internal class Default : ICommand
    {
        public string Name { get; set; } = "Default";

        public string Execute(GameController gameController, params string[] parametrs)
        {
            return "Такой команды нет, введите \"помощь\" для вывода доступных";
        }
    }
}
