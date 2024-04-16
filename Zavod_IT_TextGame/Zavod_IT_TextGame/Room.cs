using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public class Room: GameObject// можно было для создания Кухни или коридора создавать собственные классы, но я решил, будет быстрее и проще не использовать наследование
    {
        public string Name { get; set; } = "Неизвестно";
        public RoomState RoomState = new RoomState();
        private List<Item> items=new();
        private List<ICommand> actions=new();
        public List<Room> AdjoiningRooms { get;  set; }=new List<Room>();
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
            string s_actions = " можно - ";
            if (actions.Any())
            {
                foreach (ICommand command in actions)
                {
                    s_actions += command.Name + ", ";
                }
                s_actions=s_actions.Substring(0, s_actions.Length - 2)+". ";
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
                s_canGoTo = s_canGoTo.Substring(0, s_canGoTo.Length - 2) + ". ";
                message += s_canGoTo;
            }
            else message += " Вы в тупике. ";
            return message.Trim()+ " ";
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
        public Item? GetItem(string item)
        {
            Item? Item = items.FirstOrDefault(x => x.Name == item);
            return Item;
        }
        public List<Item> GetAllItems()
        {
            return items;
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
            if (AdjoiningRooms == null) AdjoiningRooms = new List<Room>();
            AdjoiningRooms.Add(room);   
        }
        public void AddAdjoiningRoom(params Room[] room)
        {
            foreach(Room room1 in room)
                AddAdjoiningRoom(room1);
        }

        public void Enter()
        {
            OnEnter?.Invoke();
        }
    }
}
