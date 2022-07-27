using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Tecidolandia.Models.Entities
{
    [Table("STATUS")]
    public class Status
    {
        [Key]
        [Column("ID_STATUS")]
        public Int64 IdStatus { get; set; }

        [Column("NM_STATUS")]
        [Display(Name = "Williann")]
        public string NmStatus { get; set; }

        [Column("STATUS_VENDA")]
        public bool StatusVenda { get; set; }

    }
}