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
        [Display(Name = "Registro da Venda")]
        [Column("ID_VENDA")]
        public Int64 IdVenda { get; set; }

        [Column("DT_REGISTRO")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Data de Registro")]
        public DateTime DtRegistro { get; set; }

        [ForeignKey("Clientes")]
        [Column("ID_CLIENTE")]
        [Display(Name = "Registro do Cliente")]
        public Int64 IdCliente { get; set; }

        [ForeignKey("Vendedores")]
        [Column("ID_VENDEDOR")]
        [Display(Name = "Regsitro do Vendedor")]
        public Int64 IdVendedor { get; set; }

        [ForeignKey("Status")]
        [Column("ID_STATUS")]
        [Display(Name = "Registro do Status")]
        public Int64 IdStatus { get; set; }

        [Column("VL_TOTAL")]
        [Display(Name = "Valor Total")]
        public double VlTotal { get; set; }

        //propriedades de navegação
        public virtual Cliente Clientes { get; set; }
        public virtual Vendedor Vendedores { get; set; }
        public virtual Status Status { get; set; }

        //public virtual Status VendaItem { get; set; }
    }
}