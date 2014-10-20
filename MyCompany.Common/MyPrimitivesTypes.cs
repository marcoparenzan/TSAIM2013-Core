using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Common
{
    public static class MyPrimitivesTypes
    {
        public static void MaggioreDiZero(int n)
        {
            if (n < 0)
            {
                MyLogs.Log("n deve essere maggiore di zero");
                throw new ArgumentOutOfRangeException(
                    "n deve essere maggiore di zero");
            }
        }
    }
}
