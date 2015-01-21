using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheRoom.Model
{
    public class Player
    {
        public string Name { get; set; }
        public string CurrentRoom { get; set; }
        public List<Thing> Things { get; set; }

        public Player()
        {
            Things = new List<Thing>();
        }
    }
}
