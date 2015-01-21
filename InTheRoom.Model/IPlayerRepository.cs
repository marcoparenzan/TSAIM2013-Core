using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InTheRoom.Model
{
    public interface IPlayerRepository
    {
        Player Get(string name);
        void Save(Player player);
    }
}
