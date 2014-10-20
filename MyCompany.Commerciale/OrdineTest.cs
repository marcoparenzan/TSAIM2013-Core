using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Commerciale
{
    static class OrdineTest
    {
        public static void Usage()
        {
            var ordine = new Ordine();
            ordine.SetNumeroOrdine(5);
            // ordine.NumeroOrdine = 5;
            ordine.NumeroOrdineAssegnato += (o, e) =>
            {
                Console.WriteLine("E' stato assegnato il numero di ordine {0}", e);
            };
 
            if (ordine.GetNumeroOrdine() == 5)
            { 
            }
            else if (ordine.NumeroOrdine == 5)
            { 
            }

            Console.WriteLine(ordine.NumeroOrdineConAnno);
        }
    }
}
