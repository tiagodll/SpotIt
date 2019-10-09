using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpotIt.Shared
{
    public class InMemoryDb
    {
        public List<Game> Rooms;

        public InMemoryDb()
        {
            Rooms = new List<Game>();
        }
    }
}
