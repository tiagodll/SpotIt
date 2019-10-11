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

        public string GetItemClass(int size, int i)
        {
            return $"spotit-card-1 spotit-icon spotit-icon-{i} {GetItemSizeClass(size, i)}";
        }
        public string GetItemSizeClass(int size, int i) 
        {
            if (i == 0)
                return "spotit-xl";
            
            if (i == 1 || i == 2)
                return "spotit-l";
            
            if (i == size - 1)
                return "spotit-xs";
            
            if (i == size - 2 || i == size - 3)
                return "spotit-s";

            return $"spotit-m";
        }
    }
}
