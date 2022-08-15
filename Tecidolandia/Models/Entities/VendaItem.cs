using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tecidolandia.Models.Entities
{
    [Table("VENDA_ITEM")]
    public class VendaItem
    {
        [Key]
        [Column("ID_VENDA_ITEM")]
        public Int64 IdVendaItem { get; set; }

        [ForeignKey("Produtos")]
        [Column("ID_PRODUTO")]
        public Int64 IdProduto { get; set; }

        [ForeignKey("Vendas")]
        [Column("ID_VENDA")]
        [Display(Name = "Id da Venda")]
        public Int64 IdVenda { get; set; }

        [Column("QUANTIDADE")]
        public int Quantidade { get; set; }

        [Column("VL_TOTAL")]
        [DataType(DataType.Currency)]
        [Display(Name = "Valor Total")]
        public double VlTotal { get; set; }

        //propriedades de navegação
        public virtual Produto Produtos { get; set; }
        public virtual Venda Vendas { get; set; }
    }
}