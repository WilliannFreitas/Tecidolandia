using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tecidolandia.Models.Entities;

namespace Tecidolandia.Models.ViewEntities
{
    public class OrdemDeVendaViewModel
    {

        public long IdVenda { get; set; }
        public long? IdVendedor { get; set; }
        public List<Vendedor> VendedorList { get; set; }
        public long? IdCliente { get; set; }
        public List<Cliente> ClienteList { get; set; }
        public long? IdStatus { get; set; }
        public List<Status> StatusList { get; set; }
        public Venda Venda { get; set; }

        public long? IdProduto { get; set; }
        public List<Produto> ProdutoList { get; set; }
      
        public List<VendaItemValor> VendaItemValor { get; set; }
        public long? Quantidade { get; set; }
        public long? ValorProduto { get; set; }
    }

    public class VendaItemValor : VendaItem
    {
        public double ValorTotalVenda { get; set; }

    }


}