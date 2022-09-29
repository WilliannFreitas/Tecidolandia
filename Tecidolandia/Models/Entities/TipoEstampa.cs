using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecidolandia.Models.Entities
{
    [Table("TIPO_ESTAMPA")]
    public class TipoEstampa
    {
        [Key]
        [Column("ID_TIPO_ESTAMPA", Order = 2)]
        public Int64 IdTipoEstampa { get; set; }

        [Column("NOME", Order = 3)]
        [Display(Name = "Nome da Estampa")]
        public string Nome { get; set; }

        [MaxLength(255)]
        [Column("DESCRICAO", Order = 4)]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        [Column("VL_METRO")]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Display(Name = "Valor do Metro")]
        public double VlMetro { get; set; }
    }
}