using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public class Room
    {
        public string Name { get; set; }    
        public ItemCollection _items=new();
        private Room[] AdjoiningRooms=[];
        public Room(string name) 
        {
            Name = name;
        }
        public void AddItem(Item item)
        {
            _items.Add(item.Name, item);
        }
        public bool Contains(Item item) { 
            if(_items.ContainsValue(item)) return true;
            return false;
        }
        public void AddAdjoiningRoom(Room room)
        {
            AdjoiningRooms.Append(room);
        }
    }
}
