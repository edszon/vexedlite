using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vxdlite.Models;
using System.Web.ModelBinding;

namespace vxdlite
{
    public partial class ProductList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<Produto> GetProducts([QueryString("id")] int? categoryId)
        {
            var _db = new vxdlite.Models.ApplicationDbContext();
            IQueryable<Produto> query = _db.Produtoes;
            if (categoryId.HasValue && categoryId > 0)
            {
                query = query.Where(p => p.CategoriaID == categoryId);
            }
            else
            {
                query = query.Where(p => p.CategoriaID == categoryId).Where(p => p.ProdutoVisivel == true);
            }
            return query;
        }
    }
}