using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Common
{
    public static class Valuta
    {
        public static decimal PiuIVA(decimal v)
        {
            return v * 1.22M;
        }

        public static void Test()
        {
            decimal quantita = 10.5M;
            decimal prezzo = 20.0M;

            decimal totale = 
                PiuIVA(quantita) 
                * PiuIVA(prezzo)
            ;
        }
    }
}
