using MyCompany.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCompany.Commerciale
{
    public class Ordine
    {
        public string Password { private get; set; }

        private int _numeroOrdine;

        public string NumeroOrdineConAnno
        {
            get
            {
                return string.Format("{0}/{1}", _numeroOrdine, DateTime.Now.Year);
            }
        }

        public int NumeroOrdine
        {
            get { return _numeroOrdine; }
            private set {
                MyPrimitivesTypes.MaggioreDiZero(value);
                _numeroOrdine = value; }
        }

        public int GetNumeroOrdine()
        {
            return _numeroOrdine;
        }

        public void SetNumeroOrdine(int numeroOrdine)
        {
            MyPrimitivesTypes.MaggioreDiZero(numeroOrdine);
            NotificaNumeroOrdineAssegnato(numeroOrdine);
            _numeroOrdine = numeroOrdine;
        }

        private void NotificaNumeroOrdineAssegnato(int numeroOrdine)
        {
            if (NumeroOrdineAssegnato != null)
            {
                NumeroOrdineAssegnato(this, numeroOrdine);
            }
        }

        public event EventHandler<int> NumeroOrdineAssegnato;
    }
}
