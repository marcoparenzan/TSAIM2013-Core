using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheRoom.Model
{
    public interface IRoomRepository
    {
        IRoom Get(Player player);
        void Save(IRoom room, Player player);
    }
}
