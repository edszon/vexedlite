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
    public class ProdutoComment
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CommentId { get; set; }

        [Required, StringLength(1000)]
        public string Comments { get; set; }

        [Required]
        public DateTime ThisDateTime { get; set; }

        public int ProdutoID { get; set; }

        public virtual Produto Produto { get; set; }

        [Range(1, 5)]
        public int Rating { get; set; }

    }
}