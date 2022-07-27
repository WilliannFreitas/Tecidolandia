using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tecidolandia.Models.Entities
{

    [Table("PRODUTO")]
    public class Produto
    {
        [Key]
        [Column("ID_PRODUTO")]
        public Int64 IdProduto { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        //[Required(ErrorMessage = "O campo largura é obrigatório")]
        //[Column("LARGURA", TypeName = "decimal(4, 2)")]
        [Column("LARGURA")]
        public decimal Largura { get; set; }

        //[Required(ErrorMessage = "O campo altura é obrigatório")]
        //[Column("ALTURA", TypeName = "decimal(4, 2)")]
        [Column("ALTURA")]
        public decimal Altura { get; set; }

        [ForeignKey("TipoEstampas")]
        [Column("ID_TIPO_ESTAMPA")]
        public Int64 IdTipoEstampa { get; set; }

        [Column("DT_REGISTRO")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de registro")]
        public DateTime? DtRegistro { get; set; }

        //propriedades de navegação
        public virtual TipoEstampa TipoEstampas { get; set; }
    }

}