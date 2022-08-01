using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tecidolandia.Models.Entities
{
    [Table("CLIENTE")]
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage = "O campo nome é obrigatório")]
        [Column("ID_CLIENTE")]
        public int IdCliente { get; set; }

        [Column("NM_COMPLETO")]
        [Display(Name = "Nome Completo")]
        public string NmCompleto { get; set; }

        [Column("FACEBOOK")]
        public string Facebook { get; set; }

        [Column("DT_REGISTRO")]
        [Display(Name = "Data de registro")]
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DtRegistro { get; set; }
    }
}