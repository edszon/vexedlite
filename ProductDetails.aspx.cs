using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using vxdlite.Models;
using System.Web.ModelBinding;
using System.Data.SqlClient;

namespace vxdlite
{
    public partial class ProductDetails : System.Web.UI.Page
    {

        SqlConnection con = new SqlConnection(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\aspnet-vxdlite-20220324045605.mdf;Initial Catalog=aspnet-vxdlite-20220324045605;Integrated Security=True;MultipleActiveResultSets=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public int pid { get; set; }


        public IQueryable<Produto> GetProduct([QueryString("productID")] int? productId)
        {
            var _db = new vxdlite.Models.ApplicationDbContext();
            IQueryable<Produto> query = _db.Produtoes;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProdutoID == productId);
            }
            else
            {
                query = null;
            }
            return query;

            pid = productId.Value;
        }


        protected void btnadd_Click(object sender, EventArgs e)
        {
            int prodid = Convert.ToInt32(Request.QueryString["productID"]);
            string usercomm = Convert.ToString(avaliacaocomment.Text);
            int starrating = Convert.ToInt32(avaliacaostar.Text);
            if (starrating > 5)
            {
                starrating = 5;
            }
            else if (starrating < 1)
            {
                starrating = 1;
            }
            DateTime commentday = DateTime.Today;
            con.Open();
            string avaliacao = "insert into ProdutoComments(ThisDateTime,ProdutoID,Comments,Rating) values('"+commentday+"','" +prodid+"','" + usercomm + "','" + starrating + "')";
            SqlCommand cmd = new SqlCommand(avaliacao, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }


        public IQueryable<ProdutoComment> GetComment([QueryString("productID")] int? productId)
        {
            var _db = new vxdlite.Models.ApplicationDbContext();
            IQueryable<ProdutoComment> query = _db.ProdutoComments;
            if (productId.HasValue && productId > 0)
            {
                query = query.Where(p => p.ProdutoID == productId);
            }
            else
            {
                query = null;
            }
            return query;
        }

        protected void btnadd_Click1(object sender, EventArgs e)
        {

        }
    }
}