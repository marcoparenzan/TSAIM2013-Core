using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi
{
    public interface IRicalcolo
    {
        void Calcola();
        decimal Totale { get; }
    }
}
