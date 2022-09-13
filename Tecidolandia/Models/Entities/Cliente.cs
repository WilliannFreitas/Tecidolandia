﻿using System;
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
        [Column("ID_CLIENTE")]
        public Int64 IdCliente { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [Column("NM_COMPLETO")]
        [Display(Name = "*Nome Completo")]
        public string NmCompleto { get; set; }

        [Column("FACEBOOK")]
        public string Facebook { get; set; }

        [Column("DT_REGISTRO")]
        //[Display(Name = "Data de registro")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DtRegistro { get; set; }

        //[Required(ErrorMessage = "O campo telefone é obrigatório")]
        //[StringLength(14, MinimumLength = 9, ErrorMessage = "Adicione o DDD com 2 caracteres e o telefone com 9 caracteres")]
        [RegularExpression(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Telefone Inválido")]
        [Column("TELEFONE_1")]
        [Display(Name = "*(DDD) Telefone Celular")]
        [DisplayFormat(DataFormatString = @"{0:(##) # ####-####}")]
        public long NuDDDTelefone1 { get; set; }

        [Column("TELEFONE_ATIVO_1")]
        [Display(Name = "Telefone celular ativo?")]
        public bool TelefoneAtivo1 { get; set; }

        [RegularExpression(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$", ErrorMessage = "Telefone Inválido")]
        //[StringLength(14, MinimumLength = 9, ErrorMessage = "Adicione o DDD com 2 caracteres e o telefone com 9 caracteres")]
        [Column("TELEFONE_2")]
        [Display(Name = "(DDD) Telefone Fixo")]
        [DisplayFormat(DataFormatString = @"{0:(##) ####-####}")]
        public long? NuDDDTelefone2 { get; set; }

        [Column("TELEFONE_ATIVO_2")]
        [Display(Name = "Telefone fixo ativo?")]
        public bool TelefoneAtivo2 { get; set; }
    }
}