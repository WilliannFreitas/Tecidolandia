using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tecidolandia.Models.Entities
{
    [Table("TIPO_ESTAMPA")]
    public class TipoEstampa
    {
        [Key]
        [Column("ID_TIPO_ESTAMPA")]
        public Int64 IdTipoEstampa { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [MaxLength(255)]
        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo valor do metro é obrigatório")]
        [Column("VL_METRO")]
        //[Range(10, 999.99,
        //     ErrorMessage = "O Preço de Venda deve estar entre " +
        //                    "10,00 e 99999,99.")]
        [Display(Name = "Valor do Metro")]
        //[DataType(DataType.Currency)]
        //[Display(Name = "Price", ResourceType = typeof(Resources.Language))]
        public double? VlMetro { get; set; }
    }
}