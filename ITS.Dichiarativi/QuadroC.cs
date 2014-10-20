using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi
{
    public class QuadroC : IQuadro
    {
        public decimal C1 { get; set; }
        public decimal C2 { get; set; }

        public void Calcola()
        {
            C2 = C1 * 1.22M;
        }

        public decimal Totale
        {
            get { return C2; }
        }
    }
}
