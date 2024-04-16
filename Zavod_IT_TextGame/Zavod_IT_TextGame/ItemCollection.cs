using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zavod_IT_TextGame
{
    public class ItemCollection : Dictionary<string,Item>
    {
        public new void Add(string name,Item item)
        {
            base.Add(name,item);
        }

    }
}
