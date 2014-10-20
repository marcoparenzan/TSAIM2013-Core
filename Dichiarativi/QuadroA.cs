using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dichiarativi
{
    public abstract class QuadroA
    {
        protected string _codiceFiscale;
        public string CodiceFiscale
        {
            get { return _codiceFiscale; }
            set {
                value.IsCodiceFiscale();
                _codiceFiscale = value; }
        }

        private string _cognome;
        public string Cognome
        {
            get { return _cognome; }
            set {
                _cognome = StringManipulation.MaxLength(value, 50);
            }
        }
        private string _nome;

        public string Nome
        {
            get { return _nome; }
            set { _nome = value.MaxLength(50); }
        }

        public DateTime DataNascita { get; set; }
        public string ComuneNascita { get; set; }
        public Sesso Sesso { get; set; }
        public abstract void Calcola();

    }
}
