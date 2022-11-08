using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Column("LARGURA")]
        [DisplayFormat(DataFormatString = "{0:F}", ApplyFormatInEditMode = true)]
        public double Largura { get; set; }

        [Column("ALTURA")]
        [DisplayFormat(DataFormatString = "{0:F}", ApplyFormatInEditMode = true)]
        public double Altura { get; set; }

        [ForeignKey("TipoEstampas")]
        [Column("ID_TIPO_ESTAMPA")]
        [Display(Name = "Nome da Estampa")]
        public Int64 IdTipoEstampa { get; set; }

        [Column("DT_REGISTRO")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DtRegistro { get; set; }

        //propriedades de navegação

        [Display(Name = "Tipo de Estampa")]
        public virtual TipoEstampa TipoEstampas { get; set; }
    }

}