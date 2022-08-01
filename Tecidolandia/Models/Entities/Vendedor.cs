using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tecidolandia.Models.Entities
{
    [Table("VENDEDOR")]
    public class Vendedor
    {
        [Key]
        [Column("ID_VENDEDOR")]
        public int IdVendedor { get; set; }

        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [Column("NOME")]
        public String Nome { get; set; }

        [Column("DT_NASC")]
        public DateTime DtNasc { get; set; }
    }
}