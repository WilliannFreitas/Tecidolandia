﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tecidolandia.Models.Entities
{
    [Table("TELEFONE")]
    public class Telefone
    {
        [Key]
        [Column("ID_TELEFONE")]
        public int IdTelefone { get; set; }

        [Required(ErrorMessage = "O campo DDD é obrigatório")]
        [Column("DDD")]
        public int Ddd { get; set; }

        [Required(ErrorMessage = "O campo telefone é obrigatório")]
        [Column("TELEFONE")]
        [Display(Name = "Telefone")]
        public int NuTelefone { get; set; }

        [ForeignKey("Cliente")]
        [Column("ID_CLIENTE")]
        public Int64 IdCliente { get; set; }

        [Column("ATIVO")]
        public int Ativo { get; set; }

        //propriedades de navegação
        public virtual Cliente Cliente { get; set; }
        public virtual Vendedor Vendedor { get; set; }
    }
}