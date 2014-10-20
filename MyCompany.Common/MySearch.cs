using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Common
{
    public static class MySearch
    {
        public static bool Contains(int[] values, int target)
        {
            bool found = false;
            foreach (int v in values)
            {
                if (v == target)
                {
                    found = true;
                    break;
                }
            }
            return found;
        }

        public enum TipoIntornoDiN
        {
            MinoreDiN
            ,
            MaggioreDiN
        }

        public static IEnumerable<int> IntornoDiN(
            IEnumerable<int> values, int n, TipoIntornoDiN tipo)
        {
            List<int> target = new List<int>();
            foreach (var v in values)
            {
                switch(tipo)
                {
                    case TipoIntornoDiN.MinoreDiN: // minore di n
                        if (v < n)
                        {
                            target.Add(v);
                        }
                        break;
                    case TipoIntornoDiN.MaggioreDiN: // maggiore di n
                        if (v > n)
                        {
                            target.Add(v);
                        }
                        break;
                }
            }
            return target;
        }

        private static int MinoreDi5(int n)
        {
            return (n < 5) ? 0 : -1 ;
        }

        public static List<int> Filtra(this IEnumerable<int> values, Func<int, bool> predicate)
        {
            List<int> target = new List<int>();
            foreach (var v in values)
            {
                if (predicate(v) )
                {
                    target.Add(v);
                }
            }
            return target;
        }

        class NeNx2
        {
            public int n;
            public int nx2;
        }

        public static void Test()
        {
            int[] values = null;
            int n = 5;

            var m = 5.0M;

            int a = (int) 5.0;

            IEnumerable<int> filtrate = values.Filtra(v => v < n);
            // filtrate.Add(n+1);
            var xxx = filtrate.Select(xx => new { 
            
                n = xx
                ,
                nx2 = xx*2
            
            });
            foreach (var x in xxx)
            {
                Console.WriteLine(x.nx2);
            }
        }
    }
}
