using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Common
{
    public struct EURO
    {
        public decimal Valore;

        public EURO PiuIva()
        {
            EURO e = new EURO();
            e.Valore = e.Valore * 1.22M;
            return e;
        }
    }
}
