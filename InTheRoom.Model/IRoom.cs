using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheRoom.Model
{
    public interface IRoom
    {
        string Name { get; }
        IEnumerable<ThingDTO> Look();
        Thing Take(string name);
        void Use(Thing thing);
    }
}
