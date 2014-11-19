namespace ITS.DichiarativiMVC.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Dichiarativi")]
    public partial class Dichiarativo
    {
        [Key]
        public int DichiarativoId { get; set; }

        [StringLength(16)]
        public string CodiceFiscale { get; set; }

        public int Anno { get; set; }

        public decimal RN01 { get; set; }

        public decimal RN02 { get; set; }

        public decimal? RS01 { get; set; }

        public decimal? RS02 { get; set; }

        public decimal Totale { get; set; }
    }
}
