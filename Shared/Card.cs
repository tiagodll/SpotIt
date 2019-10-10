using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotIt.Shared
{
    public class Card
    {
        public string id { get; set; }
        public List<int> items { get; set; }

        public Card()
        {
            this.items = new List<int>();
        }
    }
}
