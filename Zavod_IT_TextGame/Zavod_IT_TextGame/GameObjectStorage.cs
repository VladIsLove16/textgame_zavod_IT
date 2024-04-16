using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Zavod_IT_TextGame.Commands;

namespace Zavod_IT_TextGame
{
    public static class GameObjectStorage
    {
        private static Dictionary<string, ICommand> commandDict = new Dictionary<string, ICommand>();
        private static Dictionary<string, Room> roomDict = new Dictionary<string, Room>();
        private static Dictionary<string, Item> itemDict = new Dictionary<string, Item>();
        public static void AddCommand(ICommand command,string? name)
        {
            if (name == null) AddCommand(command);
            else commandDict[name] = command;
        }
        public static void AddCommand(ICommand command)
        {
            commandDict[command.Name] = command;
        }
        public static ICommand GetCommand(string name)
        {
            if (commandDict.ContainsKey(name)) return commandDict[name];
            else return new Default();
        }
        public static List<string> GetAllCommands()
        {
            return commandDict.Keys.ToList();
        }
        public static Room? GetRoom(string name)
        {
            if (roomDict.ContainsKey(name)) return roomDict[name];
            else return null;

        }
        public static void AddRoom(Room room)
        {
            roomDict[room.Name] = room;
        }
        public static  Item? GetItem(string name)
        {
            if (itemDict.ContainsKey(name)) return itemDict[name];
            return null;
        }
        public static void AddItem(Item item)
        {
            itemDict[item.Name] = item;
        }
    }
}
