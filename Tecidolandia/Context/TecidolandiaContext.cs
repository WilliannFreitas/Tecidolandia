using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using Tecidolandia.Models.Entities;

namespace Tecidolandia.Context
{
    public class TecidolandiaContext : DbContext
    {
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<TipoEstampa> TipoEstampa { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}