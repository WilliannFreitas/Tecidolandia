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
        public int IdVendaItem { get; set; }

        [ForeignKey("Produto")]
        [Column("ID_PRODUTO")]
        public int IdProduto { get; set; }

        [ForeignKey("Venda")]
        [Column("ID_VENDA")]
        public int IdVenda { get; set; }

        [Column("QUANTIDADE")]
        public int Quantidade { get; set; }

        [Column("VL_TOTAL")]
        public int VlTotal { get; set; }

        //propriedades de navegação
        public virtual Produto Produto { get; set; }
        public virtual Venda Venda { get; set; }
    }
}