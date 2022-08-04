﻿using System;
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
        public string Nome { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        //[Required(ErrorMessage = "O campo largura é obrigatório")]
        //[Column("LARGURA", TypeName = "decimal(18, 2)")]
        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:n2}",
        //    ApplyFormatInEditMode = true,
        //    NullDisplayText = "Sem preço")]
        //[Range(1.00, 300.00, ErrorMessage = "O preço deverá ser entre 1 e 300.")]
        [Column("LARGURA")]
        //[DecimalPrecision(10, 3)]
        public double Largura { get; set; }

        //[Required(ErrorMessage = "O campo altura é obrigatório")]
        //[Column("ALTURA", TypeName = "decimal(18, 2)")]
        //[DataType(DataType.Currency)]
        //[DisplayFormat(DataFormatString = "{0:n2}",
        //    ApplyFormatInEditMode = true,
        //    NullDisplayText = "Sem preço")]
        //[Range(1.00, 300.00, ErrorMessage = "O preço deverá ser entre 1 e 300.")]
        [Column("ALTURA")]
        //[DecimalPrecision(10, 3)]
        public double Altura { get; set; }

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