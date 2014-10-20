using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntentionsAndCode
{
    public static class DecimalIntention
    {
        public static void Usage()
        {
            var importo = 20.0M.Currency().ConIVA(0.22M).ConRitenuta(0.2M);
        }
    }
}
