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
    public class Categoria
    {
        [ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoriaID { get; set; }

        [Required, StringLength(100), Display(Name = "Categoria do produto")]
        public string CategoriaNome { get; set; }

        [Display(Name = "Descrição do produto")]
        public string Descricao { get; set; }

        public virtual ICollection<Produto> Produtoes { get; set; }
    }
}