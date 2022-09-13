using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Tecidolandia.Context;

namespace Tecidolandia.Models.Entities
{

    [Table("PRODUTO")]
    public class Produto
    {
        [Key]
        [Column("ID_PRODUTO")]
        public Int64 IdProduto { get; set; }

        [Column("NOME")]
        [Display(Name = "Nome do Produto")]
        public string Nome { get; set; }

        [Column("DESCRICAO")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        //[Required(ErrorMessage = "O campo largura é obrigatório")]
        //[Column("LARGURA", TypeName = "decimal(18, 2)")]
        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:n2}",
        //    ApplyFormatInEditMode = true,
        //    NullDisplayText = "Sem preço")]
        //[Range(1.00, 300.00, ErrorMessage = "O preço deverá ser entre 1 e 300.")]
        //[DecimalPrecision(10, 3)]
        [Column("LARGURA")]
        [DisplayFormat(DataFormatString = "{0:F}", ApplyFormatInEditMode = true)]
        public double Largura { get; set; }

        //[Required(ErrorMessage = "O campo altura é obrigatório")]
        //[Column("ALTURA", TypeName = "decimal(18, 2)")]
        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:n2}",
        //    ApplyFormatInEditMode = true,
        //    NullDisplayText = "Sem preço")]
        //[Range(1.00, 300.00, ErrorMessage = "O preço deverá ser entre 1 e 300.")]
        //[DecimalPrecision(10, 3)]
        [Column("ALTURA")]
        [DisplayFormat(DataFormatString = "{0:F}", ApplyFormatInEditMode = true)]
        public double Altura { get; set; }

        [ForeignKey("TipoEstampas")]
        [Column("ID_TIPO_ESTAMPA")]
        [Display(Name = "Nome da Estampa")]
        public Int64 IdTipoEstampa { get; set; }

        [Column("DT_REGISTRO")]
        //[DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        //[Display(Name = "Data de registro")]
        public DateTime? DtRegistro { get; set; }

        //propriedades de navegação

        [Display(Name = "Tipo de Estampa")]
        public virtual TipoEstampa TipoEstampas { get; set; }
    }

}