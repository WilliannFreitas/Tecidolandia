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
        public Int64 IdVenda { get; set; }

        [Column("DT_REGISTRO")]
        public DateTime DtRegistro { get; set; }

        [ForeignKey("Clientes")]
        [Column("ID_CLIENTE")]
        public Int64 IdCliente { get; set; }

        [ForeignKey("Vendedores")]
        [Column("ID_VENDEDOR")]
        public Int64 IdVendedor { get; set; }

        [ForeignKey("Status")]
        [Column("ID_STATUS")]
        public Int64 IdStatus { get; set; }

        [Column("VL_TOTAL")]
        public decimal VlTotal { get; set; }

        //propriedades de navegação
        public virtual Cliente Clientes { get; set; }
        public virtual Vendedor Vendedores { get; set; }
        public virtual Status Status { get; set; }
    }
}