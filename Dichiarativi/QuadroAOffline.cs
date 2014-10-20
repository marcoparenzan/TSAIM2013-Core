using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dichiarativi
{
    public class QuadroAOffline: QuadroA
    {
        public void Calcola2()
        {
            _codiceFiscale = "";
        }

        public override void Calcola()
        {
            this.Cognome = this.CodiceFiscale.Substring(0, 3);
            this.Nome = this.CodiceFiscale.Substring(3, 3);
            var giornoNascita = int.Parse(this.CodiceFiscale.Substring(9, 2));
            if (giornoNascita > 40)
            {
                this.Sesso = Dichiarativi.Sesso.Femmina;
                giornoNascita = giornoNascita - 40;
            }
            else
            {
                this.Sesso = Dichiarativi.Sesso.Maschio;
            }
            this.DataNascita = new DateTime(
                int.Parse(this.CodiceFiscale.Substring(6, 2)) + 1900
                ,
                1
                ,
                giornoNascita
            );
            this.ComuneNascita = this.CodiceFiscale.Substring(11, 4);
        }
    }
}
