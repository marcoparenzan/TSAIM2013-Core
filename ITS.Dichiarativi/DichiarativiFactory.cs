using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.Dichiarativi
{
    public class DichiarativiFactory : ITS.Dichiarativi.IDichiarativi
    {
        private DichiarativiFactory()
        { 
        }

        public static readonly IDichiarativi Default 
            = new DichiarativiFactory();

        private List<IDichiarativo> _dichiarativi = 
            new List<IDichiarativo>();

        public IDichiarativo Get(int id)
        {
            var d = _dichiarativi.SingleOrDefault(xx => xx.Id == id);
            if (d != null)
            {
                return d;
            }
            else
            {
                d = new Dichiarativo2(id);
                _dichiarativi.Add(d);
                return d;
            }
            //return new Dichiarativo2(id);
        }
    }
}
