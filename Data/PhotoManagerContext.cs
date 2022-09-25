using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace Data
{
    public class PhotoManagerContext : DbContext
    {
        public PhotoManagerContext() : base("name = PhotoManagerContext") { }
        public virtual DbSet<PhotoEntity> Photos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhotoEntity>()
                .ToTable("t_fotos");
        }
    }
}
