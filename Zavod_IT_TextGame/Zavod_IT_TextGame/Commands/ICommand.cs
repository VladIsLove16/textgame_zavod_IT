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
        //Сейчас смотрю на эти бесконечные If в наследниках и понимаю что можно хотя бы для разного вида ошибок написать классы;
        //или использовать дефолтные например  if (item == null)
        //                                           throw new Exception("Такого предмета нет");
        // или использовать Pipeline
        //var pipeline = new ItemTakingPipeline()
        // .AddStep(new ValidateParametersStep())
        // .AddStep(new FindItemStep(GameObjectStorage))
        // .AddStep(new CheckRoomStep(gameController))
        // .AddStep(new ExecuteItemStep())
        // .AddStep(new UpdateGameStateStep(gameController));
    }
}
