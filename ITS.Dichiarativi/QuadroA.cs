using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi
{
    public class QuadroA: IQuadro
    {
        public decimal A1 { get; set; }
        public decimal A2 { get; set; }
        public decimal A3 { get; set; }


        void IRicalcolo.Calcola()
        {
            A3 = A1+A2;
        }

        decimal IRicalcolo.Totale
        {
            get { return A3; }
        }
    }
}
