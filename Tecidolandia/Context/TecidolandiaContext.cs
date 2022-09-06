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
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<TipoEstampa> TipoEstampas { get; set; }
        public virtual DbSet<Venda> Vendas { get; set; }
        public virtual DbSet<Vendedor> Vendedores { get; set; }
        public virtual DbSet<Telefone> Telefones { get; set; }
        public virtual DbSet<VendaItem> VendaItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Conventions.Add(new DecimalPrecisionAttributeConvention());

            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

        }

    }
}