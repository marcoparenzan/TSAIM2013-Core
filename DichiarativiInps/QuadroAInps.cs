using Dichiarativi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DichiarativiInps
{
    public class QuadroAInps: QuadroA
    {
        private Func<string, bool> _validaCF;

        public QuadroAInps(Func<string, bool> validaCF)
        {
            this._validaCF = validaCF;
        }
        public override void Calcola()
        {
            if (!_validaCF(_codiceFiscale))
            {
                throw new ArgumentNullException("CF non valido");
            }
        }
    }
}
