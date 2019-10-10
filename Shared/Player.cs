using System;
using System.Collections.Generic;
using System.Text;

namespace SpotIt.Shared
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public List<Card> Cards { get; set; }
    }
}
