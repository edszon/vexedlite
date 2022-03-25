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
    public class Fabricante
    {
        [ScaffoldColumn(false), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int FabricanteID { get; set; }

        [Required, StringLength(100), Display(Name = "Fabricante do produto")]
        public string FabricanteNome { get; set; }
        public virtual ICollection<Produto> Produtoes { get; set; }
    }
}