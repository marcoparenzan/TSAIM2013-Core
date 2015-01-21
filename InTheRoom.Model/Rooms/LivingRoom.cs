using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheRoom.Model.Rooms
{
    public class LivingRoom: IRoom
    {
        public LivingRoom() {

            Things = new List<Thing>();
            Things.Add(new Thing { Name = "Door", Type = ThingType.Door });
            Things.Add(new Thing { Name = "Coin1", Type = ThingType.Coin });
            Things.Add(new Thing { Name = "Coin2", Type = ThingType.Coin });
            Things.Add(new Thing { Name = "Coin3", Type = ThingType.Coin });
            Things.Add(new Thing { Name = "Box", Type = ThingType.Box });
        }

        public List<Thing> Things { get; set; }
        IEnumerable<ThingDTO> IRoom.Look()
        {
            throw new NotImplementedException();
        }

        Thing IRoom.Take(string name)
        {
            throw new NotImplementedException();
        }

        void IRoom.Use(Thing thing)
        {
            throw new NotImplementedException();
        }

        string IRoom.Name
        {
            get { return "Living Rooom"; }
        }
    }
}
