using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tecidolandia.Models.Entities
{
    [Table("TELEFONE")]
    public class Telefone
    {
        [Key]
        [Column("ID_TELEFONE")]
        public int IdTelefone { get; set; }

        [Required(ErrorMessage = "O campo DDD é obrigatório")]
        //[MaxLength(3)]
        [Column("DDD")]
        public int Ddd { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        //[MaxLength(9)]
        [Column("TELEFONE")]
        [Display(Name = "Telefone")]
        public int NuTelefone { get; set; }

        [ForeignKey("Cliente")]
        [Column("ID_CLIENTE")]
        public Int64 IdCliente { get; set; }

        [ForeignKey("Vendedor")]
        [Column("ID_VENDEDOR")]
        public Int64 IdVendedor { get; set; }

        [Column("ATIVO")]
        public int Ativo { get; set; }

        //propriedades de navegação
        public virtual Cliente Cliente { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }
}