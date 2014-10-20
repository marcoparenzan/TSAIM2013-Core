using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi
{
    public class QuadroB : IQuadro
    {
        public decimal B1 { get; set; }
        public decimal B2 { get; set; }
        public decimal B3 { get; set; }
        public decimal B4 { get; set; }

        public void Calcola()
        {
            B4 = B1 - B2 + B3;
        }

        public decimal Totale
        {
            get { return B4; }
        }
    }
}
