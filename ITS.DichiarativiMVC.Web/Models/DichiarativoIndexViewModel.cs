using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITS.DichiarativiMVC.Web.Models
{
    public class DichiarativoIndexViewModel
    {
        public int DichiarativoId { get;set ; }
        public string CodiceFiscale { get; set; }
        public int Anno { get; set; }
        public decimal RNTotale { get; set; }
        public decimal RSTotale { get; set; }

        public decimal Totale { get; set; }
    }
}