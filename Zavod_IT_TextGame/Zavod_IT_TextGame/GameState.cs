using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public class GameState
    {
        public Room? CurrentRoom;
        public Room? PreviousRoom;
        private List<Item> Inventory=new List<Item>();
        public void SetRoom(Room room)
        {
            PreviousRoom = CurrentRoom;
            CurrentRoom =room;
        }
        public void PutItem(Item item)
        {
            Inventory.Add(item);
        }
        public void RemoveItem(Item item) {  Inventory.Remove(item); }
    }
}
