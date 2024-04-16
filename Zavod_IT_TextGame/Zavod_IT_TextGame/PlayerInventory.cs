using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public class PlayerInventory
    {
        private List<Item> _items;
        public PlayerInventory() { }
        public void Put(Item item) 
        {
            _items.Add(item);
        }
        public void Remove(Item item)
        {
            _items.Remove(item);
        }


    }
}
