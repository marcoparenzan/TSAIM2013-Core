using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheRoom.Model.Rooms
{
    public class BedRoom: IRoom
    {
        public BedRoom(bool fill = false)
        {

            Things = new List<Thing>();
            if (fill)
            {
                Things.Add(new Thing { Name = "Door", Type = ThingType.Door });
                Things.Add(new Thing { Name = "Coin1", Type = ThingType.Coin });
                Things.Add(new Thing { Name = "Coin2", Type = ThingType.Coin });
                Things.Add(new Thing { Name = "Coin3", Type = ThingType.Coin });
                Things.Add(new Thing { Name = "Coin4", Type = ThingType.Coin });
                Things.Add(new Thing { Name = "Coin5", Type = ThingType.Coin });
                Things.Add(new Thing { Name = "Coin5", Type = ThingType.Coin });
                Things.Add(new Thing { Name = "Harry Potter", Type = ThingType.Person });
            }
        }

        public List<Thing> Things { get; set; }
        IEnumerable<ThingDTO> IRoom.Look()
        {
            return Things.Select(xx => new ThingDTO
            {
                Name = xx.Name
                ,
                Type = xx.Type
            });
        }

        Thing IRoom.Take(string name)
        {
            var thing = Things.Single(xx => xx.Name == name);
            if (thing.Type == ThingType.Door) return null;
            Things.Remove(thing);
            if (thing.Type == ThingType.Coin 
                && !Things.Any(xx => xx.Type == ThingType.Coin))
            {
                Things.Add(new Thing { Name = "Key1", Type = ThingType.Key });
            }
            return thing;
        }

        void IRoom.Use(Thing thing)
        {
            if (thing.Type == ThingType.Key)
            {
                var door = Things.Single(xx => xx.Type == ThingType.Door);
                Things.Remove(door);
            }
        }

        string IRoom.Name
        {
            get { return "Bed Rooom"; }
        }
    }
}
