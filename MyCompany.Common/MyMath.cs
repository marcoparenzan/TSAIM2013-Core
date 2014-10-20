using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Common
{
    public static class MyMath
    {
        public static int SommaPrimiNumeri(int n)
        {
            MyPrimitivesTypes.MaggioreDiZero(n);
            int somma = 0;
            int i = 0;
            while (i < n)
            {
                somma += i;
                i++;
            }
            return somma;
        }
    }
}
