using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Zavod_IT_TextGame.Commands;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Zavod_IT_TextGame
{
    public class GameController
    {
        public Room startRoom;
        public Player Player=new Player();
        public GameState GameState = new GameState();
        public void InitGame()
        {
            if(startRoom == null)
            {
                //выберите локацию сами
            }
            else GameState.CurrentRoom = startRoom;
            StartGame();
        }
        public void InitGame(Room startRoom)
        {
            GameState.CurrentRoom = startRoom;
            StartGame();
        }
        private void StartGame()
        {
            SendMessage("Игра началась");
            while (true)
            {
                GameProcess();
            }
        }
        private void GameProcess()
        {
            string? command = Console.ReadLine();
            string answer = handleCommand(command);
            SendMessage(answer);
        }

        private string handleCommand(string? command)
        {
            if (string.IsNullOrEmpty(command)) return "";
            string[] commandParts = command.Split(' ');
            string action_str = commandParts[0];
            ICommand action = GameObjectStorage.GetCommand(action_str);
            string[] parametrs= new string[commandParts.Length-1];
            for (int i = 0; i < parametrs.Length; i++)
            {
                parametrs[i] = commandParts[i+1];
            }
            string answer=action.Execute(this,parametrs);
            return answer;
        }
        private void SendMessage(string message)
        {
            Console.WriteLine(message);
        }
    }
}
