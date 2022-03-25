using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using vxdlite.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace vxdlite.Models
{
    public class Produto
    {
        [ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProdutoID { get; set; }

        [Required, StringLength(100), Display(Name = "Nome do produto")]
        public string ProdutoNome { get; set; }

        [Required,DefaultValue(true)]
        public bool ProdutoVisivel { get; set; }

        [Required, StringLength(10000), Display(Name = "Descrição do produto"), DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        public string ImagemPath { get; set; }

        [Display(Name = "Preço")]
        public double? PrecoUnitario { get; set; }

        [DefaultValue(0)]
        public int Estoque { get; set; }

        public int? CategoriaID { get; set; }

        public virtual Categoria Categoria { get; set; }

        public int? FabricanteID { get; set; }

        public virtual Fabricante Fabricante { get; set; }

    }
}