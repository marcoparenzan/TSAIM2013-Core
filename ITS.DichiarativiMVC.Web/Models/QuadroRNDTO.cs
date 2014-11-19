using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ITS.DichiarativiMVC.Web.Models
{
    public class QuadroRNDTO
    {
        public int DichiarativoId { get; set; }
        public string CodiceFiscale { get; set; }
        public int Anno { get; set; }
        public decimal RN01 { get; set; }
        public decimal RN02 { get; set; }
    }
}