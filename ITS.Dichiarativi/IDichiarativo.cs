using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi
{
    public interface IDichiarativo: IRicalcolo
    {
        int Id { get; }
        T Get<T>()
            where T : IQuadro;
    }
}
