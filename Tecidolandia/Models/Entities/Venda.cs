using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tecidolandia.Models.Entities
{
    [Table("VENDA")]
    public class Venda
    {
        [Key]
        [Column("ID_VENDA")]
        public int IdVenda { get; set; }

        [Column("DT_REGISTRO")]
        public DateTime DtRegistro { get; set; }

        [ForeignKey("Cliente")]
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }

        [ForeignKey("Vendedor")]
        [Column("ID_VENDEDOR")]
        public int IdVendedor { get; set; }

        [ForeignKey("Status")]
        [Column("ID_STATUS")]
        public int IdStatus { get; set; }

        [Column("VL_TOTAL")]
        public decimal VlTotal { get; set; }

        //propriedades de navegação
        public virtual Cliente Cliente { get; set; }
        public virtual Vendedor Vendedor { get; set; }
        public virtual Status Status { get; set; }
    }
}