using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi.Tests
{
    class Program
    {

        static IEnumerable<IDichiarativo> Dichiarazioni(
            int n
            , Func<IDichiarativo> createNew
        )
        {
            var list = new List<IDichiarativo>();

            return list;
        }

        static void Main(string[] args)
        {
            var d = DichiarativiFactory.Default.Get(1);
            Func<int, IDichiarativo> createNewDichiarativo = 
                DichiarativiFactory.Default.Get;

            var qa = d.Get<QuadroA>();
            qa.A1 = 100.0M;
            qa.A2 = 200.0M;

            var qb = d.Get<QuadroB>();
            qb.B1 = 10.0M;

            var d1 = new Dichiarativo();
            d1.QuadroA.A1 = 100.0M;
            d1.QuadroB.B2 = 10.0M;


            var calcola = d.GetType().GetMethod("Calcola");
            calcola.Invoke(d, null);

            DoSomething(DichiarativiFactory.Default);
        }

        static void DoSomething(IDichiarativi dd)
        {
            var d = dd.Get(3);
            d.Get<QuadroA>().A2 = 200.0M;
        }
    }
}
