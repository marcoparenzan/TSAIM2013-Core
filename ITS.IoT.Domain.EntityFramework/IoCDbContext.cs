using ITS.IoC.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITS.IoT.Domain.EntityFramework
{
    public class IoCDbContext: DbContext
    {
        public DbSet<MyEntity> MyEntities { get; set; }

        protected override void OnModelCreating(
            DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder
                .Entity<MyEntity>()
                .HasKey(xx => xx.Id)
                .ToTable("IoT.MyEntities")
                ;
            modelBuilder
                .Entity<MyEntity>()
                .Property(xx => xx.Id).HasColumnName("MyEntityId");

            modelBuilder
                .Entity<MyEntity>()
                .Property(xx => xx.Value).HasColumnName("Valore");

        }
    }
}
