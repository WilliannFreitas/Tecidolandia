using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Tecidolandia.Models.Entities;

namespace Tecidolandia.Models.ViewEntities
{
    public class OrdemDeVendaViewModel
    {
        public long? IdVendedor { get; set; }
        public List<Vendedor> VendedorList { get; set; }

        [Display(Name = "Selecionar Venda")]
        public long IdVenda { get; set; }
        
        [Display(Name = "*Selecionar Produto")]
        public long? IdProduto { get; set; }
        public List<Produto> ProdutoList { get; set; }
        public long? IdCliente { get; set; }
        public List<Cliente> ClienteList { get; set; }
        public long? IdStatus { get; set; }
        public List<Status> StatusList { get; set; }
        public Venda Venda { get; set; }
        public List<VendaItemValor> VendaItemValor { get; set; }
        public long? Quantidade { get; set; }

        [DataType(DataType.Currency)]
        public long? ValorProduto { get; set; }
        public Cliente ClienteSelecionado {get; set;}
        public long? ConcluirVenda { get; set;}
    }

    public class VendaItemValor : VendaItem
    {
        [DataType(DataType.Currency)]
        public double ValorUnitario { get; set; }
    }
}