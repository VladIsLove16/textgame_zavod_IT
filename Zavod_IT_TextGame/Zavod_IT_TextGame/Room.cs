using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public class Room: GameObject
    {
        public string Name { get; set; } = "Неизвестно";
        public RoomState RoomState = new RoomState();
        private List<Item> items=new();
        private List<ICommand> actions=new();
        public Room[] AdjoiningRooms { get; private set; } =[];
        public string AddjustmentEnterMessage="";
        public string PreviousEnterMessage = "";
        public string EnterMessage
        {
            get
            {
                return PreviousEnterMessage+ CreateDefaultEnterMessage() + AddjustmentEnterMessage;
            }
            private set { }
        }

        private string CreateDefaultEnterMessage()
        {
            string message = Name + ",";
            string s_actions = "можно -";
            if (actions.Any())
            {
                foreach (ICommand command in actions)
                {
                    s_actions += command.Name + ", ";
                }
                s_actions.Substring(0, s_actions.Length - 2);
                message += s_actions;
            }
            else message += "ничего интересного. ";
            if (AdjoiningRooms.Any())
            {
                string s_canGoTo = "Можно пройти - ";
                foreach (Room room in AdjoiningRooms)
                {
                    s_canGoTo += room.Name + ", ";
                }
            }
            else message += "Вы в тупике. ";
            return message.Trim();
        }

        delegate void RoomHandler();
        event RoomHandler? OnEnter;
        public Room() { }
        public Room(string name) 
        {
            Name = name;
        }
        public Room(string name,string enterMessage)
        {
            Name = name;
            EnterMessage = enterMessage;
        }
        public void AddItem(Item item)
        {
            items.Add(item);
        }
        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }
        public Item? GetItem(Item item)
        {
            if(items.Contains(item))
            {
                return items.FirstOrDefault(item);
            }
            return null;
        }
        public Item? GetItem(string item)
        {
            Item Item= new Item(item); 
            return GetItem(Item);
        }
        public void AddAction(ICommand command)
        {
            actions.Add(command);
        }
        public void RemoveAction(ICommand command)
        {
            actions.Remove(command);
        }
        public void AddAdjoiningRoom(Room room)
        {
            AdjoiningRooms.Append(room);
        }
        public void AddAdjoiningRoom(params Room[] room)
        {
            foreach(Room room1 in room)
             AdjoiningRooms.Append(room1);
        }

        public void Enter()
        {
            OnEnter?.Invoke();
        }
    }
}
