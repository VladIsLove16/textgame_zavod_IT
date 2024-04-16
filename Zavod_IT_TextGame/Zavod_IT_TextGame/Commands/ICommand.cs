using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public interface ICommand
    {
        public string Name {  get; set; }   
        public string Execute(GameController gameController,params string[] parametrs);  
    }
}
