using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public class GameState
    {
        public Room CurrentRoom;
        public Room PreviousRoom;
        public List<Item> Inventory;
        public void SetRoom(Room room)
        {
            PreviousRoom = CurrentRoom;
            CurrentRoom =room;
        }
    }
}
