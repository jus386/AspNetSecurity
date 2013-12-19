using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web.Configuration;
using InjectionLINQ.Data;

namespace InjectionLINQ
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearchTerm.Text;
            using (NorthwindDataContext context = new NorthwindDataContext())
            {
                var q = from p in context.Products
                        where p.ProductName.Contains(searchTerm)
                        select p;

                this.ProductGridView.DataSource = q;
                this.ProductGridView.DataBind();
                this.ProductCount.Text = this.ProductGridView.Rows.Count.ToString("n0");
                this.SearchPanel.Visible = true;

            }
        }
    }
}