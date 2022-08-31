using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Tecidolandia.Context;

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

        //[Required(ErrorMessage = "O campo valor do metro é obrigatório")]       
        //[DisplayFormat(DataFormatString = "{0:n2}",
        //    ApplyFormatInEditMode = true,
        //    NullDisplayText = "Sem preço")]
        //[Range(1.00, 300.00, ErrorMessage = "O preço deverá ser entre 1 e 300.")]
        //[Column("VL_METRO", Order = 1, TypeName = "decimal(18,2)")]
        //[RegularExpression(@"^\$?\d+(\.(\d{2}))?$")]
        //[Column(TypeName = "money")]
        //[Column(Order = 3)]
        //[Display(Name = "Price", ResourceType = typeof(Resources.Language))]
        //[Column("VL_METRO", TypeName = "money")]
        [DataType(DataType.Currency)]
        [Column("VL_METRO")]
        [Display(Name = "Valor do metro")]
        public double VlMetro { get; set; }
    }
}
        //[DecimalPrecision(10, 3)] 