using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public static class GameObjectStorage
    {
        private static Dictionary<string, ICommand> commandDict = new Dictionary<string, ICommand>();
        private static Dictionary<string, Room> roomDict = new Dictionary<string, Room>();
        private static Dictionary<string, Item> itemDict = new Dictionary<string, Item>();
        public static void AddCommand(string name, ICommand command)
        {
            commandDict[name] = command;
        }
        public static ICommand? GetCommand(string name)
        {
            if (commandDict.ContainsKey(name)) return commandDict[name];
            else return null;
        }
        public static ICommand[] GetAllCommands()
        {
            return commandDict.Values.ToArray();
        }
        public static Room GetRoom(string name)
        {
            return roomDict[name];
        }
        public static void AddRoom(Room room)
        {
            roomDict[room.Name] = room;
        }
        public static  Item GetItem(string name)
        {
            return itemDict[name];
        }
        public static void AddItem(Item item)
        {
            itemDict[item.Name] = item;
        }
    }
}
