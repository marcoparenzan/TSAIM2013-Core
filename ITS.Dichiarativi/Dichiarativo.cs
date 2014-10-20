using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi
{
    public class Dichiarativo: IRicalcolo
    {
        public Dichiarativo()
        {
            QuadroA = new QuadroA();
            QuadroB = new QuadroB();
            QuadroC = new QuadroC();

        }
        public QuadroA QuadroA { get; set; }
        public QuadroB QuadroB { get; set; }
        public QuadroC QuadroC { get; set; }

        public decimal Totale { get; set; }
        public void Calcola()
        {
            ((IRicalcolo)QuadroA).Calcola();
            QuadroB.Calcola();
            QuadroC.Calcola();
            Totale = ((IRicalcolo) QuadroA).Totale
                    + QuadroB.Totale
                    + ((IRicalcolo) QuadroC).Totale
                ;
        }
    }
}
