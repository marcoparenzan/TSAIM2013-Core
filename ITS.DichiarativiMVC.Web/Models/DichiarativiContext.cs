using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ITS.DichiarativiMVC.Web.Models
{
    public class DichiarativiContext: DbContext
    {
        public DichiarativiContext() : 
            base("name=Dichiarativi") { 
        }
        public DbSet<Dichiarativo> Dichiarativi { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder
                .Entity<Dichiarativo>()
                .HasKey(xx => xx.DichiarativoId)
                .ToTable("Dichiarativi");
        }
    }
}